using System;
using System.Collections;
using BaseCode2._2._Services.Coroutines;
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.GlobalServices.Pools;
using BsseCode._2._Services.GlobalServices.Pools.ExplosionPool;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._2._Services.ServiceLocator;
using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.Enemy
{
    public class Enemy : MonoBehaviour, IPoolsElement
    {

        [SerializeField] private EnemyAudioController audioController;

        
        
        private IPoolController _poolController;

        private PositionUpdateService _positionUpdateService;
        private ICoroutineGlobalService _coroutineGlobalService;
        
        private GameMachineStarter _gameMachineStarter;
        private IManagersServiceLocator _managersServiceLocator;
        
     
        private float _speed;
        private Vector2 _moveDirection;
        private Vector2 _diePosition;

        [Inject]
        public void Construct(
            PositionUpdateService positionUpdateService,
            IPoolController poolController,
            ICoroutineGlobalService coroutineGlobalService,
            GameMachineStarter gameMachineStarter,
            IManagersServiceLocator managersServiceLocator
            )
        {
            _managersServiceLocator = managersServiceLocator ?? throw new ArgumentNullException(nameof(managersServiceLocator));
            _gameMachineStarter = gameMachineStarter ?? throw new ArgumentNullException(nameof(gameMachineStarter));
            
            
            _coroutineGlobalService =
                coroutineGlobalService ?? throw new ArgumentNullException(nameof(coroutineGlobalService));
            _positionUpdateService =
                positionUpdateService ?? throw new ArgumentNullException(nameof(positionUpdateService));
            _poolController = poolController ?? throw new ArgumentNullException(nameof(poolController));

            if (_gameMachineStarter.MainMenuState == null)
            {
                Debug.LogError("MainMenuState is null!");
                return;
            }

            _gameMachineStarter.MainMenuState.OnMenuState += Deactivaite;
        }


        public void SetParameters(float speed)
        {
            _speed = speed;
        }


        private void Update()
        {
            Direction();
            Rotation();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Bullet.Bullet>(out Bullet.Bullet bullet))
            {
                ReturnToPool();
            }
        }

        public void ReturnToPool()
        {
            _coroutineGlobalService.StartCoroutine(PostMortemEventHandler());
            Deactivaite();
        }

        private void Deactivaite()
        {
            _poolController.ReturnToPool(this);
        }

        private void Rotation()
        {
            float angle = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void Direction()
        {
            if (_managersServiceLocator.BeaconHandler.IsActive)
            {
                _moveDirection = _managersServiceLocator.BeaconHandler.BaaconControllerPosition - transform.position;
            }
            else
            {
                _moveDirection = _managersServiceLocator.PlayerHandler.CurrentPlayer.transform.position - transform.position;
            }
            _moveDirection.Normalize();
            Vector2 newPosition = _positionUpdateService.Move(_moveDirection, _speed, this.transform.position);
            transform.position = newPosition;
        }

        private IEnumerator PostMortemEventHandler()
        {
            _diePosition = transform.position;
            CreateExplosion();
            audioController.ExplosionSound();
            yield return new WaitForSeconds(0.1f);
            _managersServiceLocator.KillsController.OnEnemyKilled();
            yield return new WaitForSeconds(0.5f);
            CreateExplosionResidue();
            yield return new WaitForSeconds(0.2f);
            CreateAmmoLoot();
        }

        private void CreateExplosionResidue()
        {
            var element = _poolController.GetPool<AfterDeathMarks.AfterDeathMarks>().GetElement();
            element.transform.position = _diePosition;
        }

        private void CreateExplosion()
        {
            var element = _poolController.GetPool<Explosion.Explosion>().GetElement();
            element.transform.position = _diePosition;
        }

        private void CreateAmmoLoot()
        {
            var element = _poolController.GetPool<EnergyLoot.EnergyLoot>().GetElement();
            element.transform.position = _diePosition;
        }

        private void OnDestroy()
        {
            _gameMachineStarter.MainMenuState.OnMenuState -= Deactivaite;
        }

    }
}
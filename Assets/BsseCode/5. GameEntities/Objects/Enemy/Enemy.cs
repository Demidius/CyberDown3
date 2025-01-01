using System;
using System.Collections;
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.GlobalServices.Coroutines;
using BsseCode._2._Services.GlobalServices.PlayerHandlerFl;
using BsseCode._2._Services.GlobalServices.Pools;
using BsseCode._2._Services.GlobalServices.Pools.ExplosionPool;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._5._GameEntities.Hero;
using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.Enemy
{
    public class Enemy : MonoBehaviour, IPoolsElement
    {

        [SerializeField] private EnemyAudioController audioController;

        private ExplosionSpawner _explosionSpawner;
        
        private IPoolController _poolController;
        private float _speed;

        private PositionUpdateService _positionUpdateService;
        private Vector2 _moveDirection;
        private ICoroutineGlobalService _coroutineGlobalService;
        private KillsController _killsController;
        private PlayerHandler _playerHandler;
        private GameMachineStarter _gameMachineStarter;
        private Vector2 _diePosition;

        private bool _goToBase = false;
        private Vector3 _targetTransformPosition;

        [Inject]
        public void Construct(
            PositionUpdateService positionUpdateService,
            IPoolController poolController,
            ICoroutineGlobalService coroutineGlobalService,
            KillsController killsController,
            PlayerHandler playerHandler,
            GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter ?? throw new ArgumentNullException(nameof(gameMachineStarter));
            _playerHandler = playerHandler ?? throw new ArgumentNullException(nameof(playerHandler));
            _killsController = killsController ?? throw new ArgumentNullException(nameof(killsController));
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

            _gameMachineStarter.MainMenuState.OnMenuState += Deactivata;
        }


        public void SetParameters(float speed)
        {
            _speed = speed;
            ResetDirection();
            _gameMachineStarter.baseHandler.OnFillingStarted += SetNewDirection;
            _gameMachineStarter.baseHandler.OnFillingEndedEvent += ResetDirection;
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
                Kill();
            }
        }

        public void Kill()
        {
            _coroutineGlobalService.StartCoroutine(PostMortemEventHandler());
            Deactivata();
        }

        private void Deactivata()
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
            if (_goToBase)
            {
                _moveDirection = _targetTransformPosition - transform.position;
            }
            else
            {
                _moveDirection = _playerHandler.CurrentPlayer.transform.position - transform.position;
            }
            _moveDirection.Normalize();
            Vector2 newPosition = _positionUpdateService.Move(_moveDirection, _speed, this.transform.position);
            transform.position = newPosition;
        }

        void ResetDirection()
        {
            _goToBase = false;
        }

        void SetNewDirection(Vector3 newDirection)
        {
            _goToBase = true;
            _targetTransformPosition = newDirection;
        }

        private IEnumerator PostMortemEventHandler()
        {
            _diePosition = transform.position;
            CreateExplosion();
            audioController.ExplosionSound();
            yield return new WaitForSeconds(0.1f);
            _killsController.OnEnemyKilled();
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
            _gameMachineStarter.MainMenuState.OnMenuState -= Deactivata;
            _gameMachineStarter.baseHandler.OnFillingStarted -= SetNewDirection;
            _gameMachineStarter.baseHandler.OnFillingEndedEvent -= ResetDirection;
        }

    }
}
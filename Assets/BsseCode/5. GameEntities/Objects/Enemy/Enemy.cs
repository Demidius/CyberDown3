using System;
using System.Collections;
using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.Coroutines;
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.GlobalServices.Handlers;
using BsseCode._2._Services.GlobalServices.Pools;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._2._Services.ServiceLocator;
using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.Enemy
{
    public interface IEnemy
    {
        void SetParameters(float speed);
        void Kill();
    }

    public class Enemy : MonoBehaviour, IPoolsElement, IEnemy
    {
        [SerializeField] private EnemyAudioController audioController;

        private IPoolController _poolController;

        private IPositionUpdateService _positionUpdateService;
        private ICoroutineGlobalService _coroutineGlobalService;

        private IGameMachineModule _gameMachineModule;
        private IManagersServiceLocator _managersServiceLocator;
        private IDeathEffectsHandler _deathEffectsHandler;
        private IEnemyMovement _enemyMovement;


        private float _speed;
        private Vector2 _moveDirection;
        private Vector2 _diePosition;

        private IEnemyMovement _movement;
        private KillsController _killsController;

        [Inject]
        public void Construct(
            IPositionUpdateService positionUpdateService,
            IPoolController poolController,
            ICoroutineGlobalService coroutineGlobalService,
            IGameMachineModule gameMachineModule,
            IManagersServiceLocator managersServiceLocator,
            KillsController killsController
        )
        {
            _killsController = killsController;
            _managersServiceLocator =
                managersServiceLocator ?? throw new ArgumentNullException(nameof(managersServiceLocator));
            _gameMachineModule =
                gameMachineModule ?? throw new ArgumentNullException(nameof(gameMachineModule));
            _coroutineGlobalService =
                coroutineGlobalService ?? throw new ArgumentNullException(nameof(coroutineGlobalService));
            _positionUpdateService =
                positionUpdateService ?? throw new ArgumentNullException(nameof(positionUpdateService));
            _poolController =
                poolController ?? throw new ArgumentNullException(nameof(poolController));
        }

        public void SetParameters(float speed)
        {
            _speed = speed;
        }

        private void Awake()
        {
            _gameMachineModule.MenuState.OnMenuState += ReturnToPool;
            _deathEffectsHandler = new DeathEffectsHandler(_poolController);
            EnemyMovementRegistry();
        }

        private void EnemyMovementRegistry()
        {
            if (_managersServiceLocator?.PlayerHandler?.CurrentPlayer?.transform == null)
            {
                Debug.LogError("PlayerHandler or CurrentPlayer is null!");
                return;
            }

            _movement = gameObject.AddComponent<EnemyMovement>();
            _movement.Initialize(_positionUpdateService, _speed, _managersServiceLocator.PlayerHandler.CurrentPlayer.transform);
        }

        private void Update()
        {
            _enemyMovement.Move();
            _enemyMovement.Rotate();
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
            ReturnToPool();
        }

        public void ReturnToPool()
        {
            _poolController.ReturnToPool(this);
        }

        private IEnumerator PostMortemEventHandler()
        {
            _diePosition = transform.position;
            _deathEffectsHandler.CreateExplosion(_diePosition);
            audioController.ExplosionSound();
            yield return new WaitForSeconds(0.1f);
            _killsController.OnEnemyKilled();
            yield return new WaitForSeconds(0.5f);
            _deathEffectsHandler.CreateResidue(_diePosition);
            yield return new WaitForSeconds(0.2f);
            _deathEffectsHandler.CreateLoot(_diePosition);
        }

        private void OnDestroy()
        {
            _gameMachineModule.MenuState.OnMenuState -= ReturnToPool;
        }

        // private void Rotation()
        // {
        //     float angle = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg;
        //     transform.rotation = Quaternion.Euler(0, 0, angle);
        // }
        //
        // private void Direction()
        // {
        //     if (_managersServiceLocator.BeaconHandler.IsActive)
        //     {
        //         _moveDirection = _managersServiceLocator.BeaconHandler.BaaconControllerPosition - transform.position;
        //     }
        //     else
        //     {
        //         _moveDirection = _managersServiceLocator.PlayerHandler.CurrentPlayer.transform.position - transform.position;
        //     }
        //     _moveDirection.Normalize();
        //     Vector2 newPosition = _positionUpdateService.Move(_moveDirection, _speed, this.transform.position);
        //     transform.position = newPosition;
        // }
    }
}
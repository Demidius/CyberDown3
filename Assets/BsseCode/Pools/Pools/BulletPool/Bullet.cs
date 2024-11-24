using BsseCode.Audio;
using BsseCode.Caracters.Hero;
using BsseCode.Services;
using BsseCode.Services.Coroutines;
using UnityEngine;
using Zenject;
using FMODUnity; // Не забудь подключить FMOD Unity API

namespace BsseCode.Pools.Pools.BulletPool
{
    public class Bullet : MonoBehaviour, IPoolsElement
    {
        [SerializeField] private float lifetime = 2f;

        private float _speed;
        private Vector2 _direction;
        private BulletMover _bulletMover;
        private BulletLifeCycleManager _lifeCycleManager;
        private IPoolController _poolController;
        private Player _player;

        [EventRef]
        public string shootEvent = "event:/SHOOTING/BLASTER SHOOT"; // Путь к событию FMOD

        [Inject]
        public void Construct(
            MoveService moveService,
            IPoolController poolController,
            ICoroutineService coroutineService,
            Player player)
        {
            _player = player;
            _bulletMover = new BulletMover(moveService, transform);
            _lifeCycleManager = new BulletLifeCycleManager(coroutineService, Deactivate);
            _poolController = poolController;
        }

        private void OnEnable()
        {
            // Запуск звукового события
            RuntimeManager.PlayOneShot(shootEvent, transform.position);
            _lifeCycleManager.StartLifeRoutine(lifetime);
        }

        private void OnDisable() => _lifeCycleManager.StopLifeRoutine();

        public void SetParameters(float speed, Vector2 direction)
        {
            _speed = speed;
            _direction = direction.normalized;

            _bulletMover.SetRotationBasedOnDirection(_direction);
        }

        private void Update() => _bulletMover.Move(_direction, _speed);

        public void Deactivate() => _poolController?.ReturnToPool(this);
    }
}
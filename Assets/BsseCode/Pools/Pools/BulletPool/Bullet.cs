using BsseCode.Audio;
using BsseCode.Audio.AudioService;
using BsseCode.Caracters.Hero;
using BsseCode.Services;
using BsseCode.Services.Coroutines;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.BulletPool
{
    public class Bullet : MonoBehaviour, IPoolsElement
    {
        [SerializeField] private float lifetime = 2f;

        private float _speed;
        private Vector2 _direction;
       // private OneSoundHandler _audioHandler;
        private BulletMover _bulletMover;
        private BulletLifeCycleManager _lifeCycleManager;
        private IPoolController _poolController;
        private Player _player;
        private SoundStorage _soundStorage;
        private IAudioHandler _audioHandler;

        [Inject]
        public void Construct(
            MoveService moveService,
            IPoolController poolController,
            ICoroutineService coroutineService,
            Player player,
            SoundStorage soundStorage,
                IAudioHandler audioHandler)
        {
            _audioHandler = audioHandler;
            _soundStorage = soundStorage;
          // _audioHandler = audioHandler;
            _player = player;
            _bulletMover = new BulletMover(moveService, transform);
            _lifeCycleManager = new BulletLifeCycleManager(coroutineService, Deactivate);
            _poolController = poolController;
        }

        private void OnEnable() => _lifeCycleManager.StartLifeRoutine(lifetime);
        private void OnDisable() => _lifeCycleManager.StopLifeRoutine();

        public void SetParameters(float speed, Vector2 direction)
        {
            _speed = speed;
            _direction = direction.normalized;

            _bulletMover.SetRotationBasedOnDirection(_direction);
            _audioHandler.AudioPlay(_soundStorage.ShootGun, this.transform.position, _poolController);
        }

        private void Update() => _bulletMover.Move(_direction, _speed);

        public void Deactivate() => _poolController?.ReturnToPool(this);
    }
}
using BsseCode.Audio;
using BsseCode.Pools.Pools.EnemesPool;
using BsseCode.Services;
using BsseCode.Services.Coroutines;
using BsseCode.Services.TimeProvider;
using BsseCode.Tags;
using UnityEngine;
using Zenject;


namespace BsseCode.Pools.Pools.BulletPool
{
    public class Bullet : MonoBehaviour, IPoolsElement
    {
        
        private float _speed;
        private Vector2 _direction;
        private BulletMover _bulletMover;
      
        private IPoolController _poolController;
        private ITimeService _timeService;

        [Inject]
        public void Construct(
            MoveService moveService,
            IPoolController poolController,
            ICoroutineService coroutineService,
            ITimeService timeService)
        {
            _timeService = timeService;
            _poolController = poolController;
            _bulletMover = new BulletMover(moveService, transform);
        }
        public void SetParameters(float speed, Vector2 direction)
        {
            _speed = speed;
            _direction = direction.normalized;
            _bulletMover.SetRotationBasedOnDirection(_direction);
            // AudioManager.Instance.PlayOneShot(FMODEvents.Instance.shootSound, this.transform.position);
        }

        private void Update() => 
            _bulletMover.Move(_direction, _speed);

        public void Deactivate() => 
            _poolController?.ReturnToPool(this);

       
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                Deactivate();
            }
            else if (other.TryGetComponent<BulletDestroyer>(out BulletDestroyer bullet))
            {
                Deactivate();
            }
            
        }
        
    }
}

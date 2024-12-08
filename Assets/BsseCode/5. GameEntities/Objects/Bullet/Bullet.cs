using BsseCode._2._Services.GlobalServices.Coroutines;
using BsseCode._2._Services.GlobalServices.Pools;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._3._SupportCode.Tags;
using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.Bullet
{
    public class Bullet : MonoBehaviour, IPoolsElement
    {
       

        private float _speed;
        private Vector2 _direction;
        private BulletMover _bulletMover;
      
        private IPoolController _poolController;
        private ITimeGlobalService _timeGlobalService;

        [Inject]
        public void Construct(
            PositionUpdateService positionUpdateService,
            IPoolController poolController,
            ICoroutineGlobalService coroutineGlobalService,
            ITimeGlobalService timeGlobalService)
        {
            _timeGlobalService = timeGlobalService;
            _poolController = poolController;
            _bulletMover = new BulletMover(positionUpdateService, transform);
        }
        
        public void SetParameters(float speed, Vector2 direction)
        {
            _speed = speed;
            _direction = direction.normalized;
            _bulletMover.SetRotationBasedOnDirection(_direction);
        }

        private void Update() => 
            _bulletMover.Move(_direction, _speed);

        public void Deactivate() => 
            _poolController?.ReturnToPool(this);
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Enemy.Enemy>(out Enemy.Enemy enemy))
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

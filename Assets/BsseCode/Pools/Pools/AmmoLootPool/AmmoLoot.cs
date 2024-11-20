using BsseCode.Mechanics.BulletCounter;
using BsseCode.Services;
using BsseCode.Tags;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.AmmoLootPool
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class AmmoLoot : MonoBehaviour, IPoolsElement
    {
       
        private float _speed;
        private MoveService _moveService;

       
        private Coroutine _coroutineLifeRoutine;
        private IBulletCounter _bulletCounter;
        private IPoolController _poolController;

        [Inject]
        public void Construct(IPoolController poolController, IBulletCounter bulletCounter)
        {
            _poolController = poolController;
            _bulletCounter = bulletCounter;
           
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerTag>(out PlayerTag player))
            {
                _bulletCounter.AddBullet();
                Deactivate();
            }
        }


        public void Deactivate()
        {
            _poolController.ReturnToPool(this);
        }
    }
}
using System.Collections;
using BsseCode.Hero;
using BsseCode.Services;
using BsseCode.Services.Coroutines;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.AmmoLootPool
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class AmmoLoot : MonoBehaviour, IPoolsElement
    {
        private IPoolsBase _poolComponent;
        private float _speed;
        private MoveService _moveService;
        
        private ICoroutineService _coroutineService;
        private Coroutine _coroutineLifeRoutine;

        public void SetParameters( IPoolsBase poolBullet, ICoroutineService coroutineService)
        {
            _coroutineService = coroutineService;
            _poolComponent = poolBullet;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerTag>(out PlayerTag player))
            {
                Deactivate();
            }
        }
       

        public void Deactivate()
        {
            _poolComponent.AmmoLootComponent?.ReturnToPool(this);

        }
    }
}
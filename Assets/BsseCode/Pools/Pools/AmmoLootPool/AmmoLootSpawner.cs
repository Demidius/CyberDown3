using BsseCode.Services.Coroutines;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.AmmoLootPool
{
    public class AmmoLootSpawner : MonoBehaviour
    {
        private Transform _bulletSpawnPoint;
        
        private IPoolsBase _poolBullet;
        
        private ICoroutineService _coroutineService;

        [Inject]
        public void Construct(IPoolsBase poolBullet,  ICoroutineService coroutineService)
        {
            _coroutineService = coroutineService;
            _poolBullet = poolBullet;
          
        }

        
        private void Spawn()
        {
            var bullet = _poolBullet.AmmoLootComponent.GetElement();
            bullet.transform.position = _bulletSpawnPoint.transform.position;
            bullet.SetParameters(_poolBullet, _coroutineService);
        }
    }
}
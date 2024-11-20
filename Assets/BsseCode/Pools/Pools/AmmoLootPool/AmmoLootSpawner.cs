using BsseCode.Mechanics.BulletCounter;
using BsseCode.Services.Coroutines;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.AmmoLootPool
{
    public class AmmoLootSpawner : MonoBehaviour
    {
        private Transform _bulletSpawnPoint;
        
        private IPoolController _poolController;


        [Inject]
        public void Construct(IPoolController poolController)
        {
            _poolController = poolController;
        }


        private void Spawn()
        {
            var bullet = _poolController.GetPool<AmmoLoot>().GetElement();
            bullet.transform.position = _bulletSpawnPoint.transform.position;
        }
    }
}
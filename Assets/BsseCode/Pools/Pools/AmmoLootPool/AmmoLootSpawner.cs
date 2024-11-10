using BsseCode.Mechanics.BulletCounter;
using BsseCode.Services.Coroutines;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.AmmoLootPool
{
    public class AmmoLootSpawner : MonoBehaviour
    {
        private Transform _bulletSpawnPoint;

        private IPoolsBase _poolBullet;

        

        [Inject]
        public void Construct(IPoolsBase poolBullet)
        {
            
            _poolBullet = poolBullet;

        }


        private void Spawn()
        {
            var bullet = _poolBullet.AmmoLootComponent.GetElement();
            bullet.transform.position = _bulletSpawnPoint.transform.position;
        }
    }
}
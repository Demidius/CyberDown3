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

        public void Spawn()
        {
            var element = _poolController.GetPool<AmmoLoot>().GetElement();
            element.transform.position = _bulletSpawnPoint.transform.position;
        }
    }
}
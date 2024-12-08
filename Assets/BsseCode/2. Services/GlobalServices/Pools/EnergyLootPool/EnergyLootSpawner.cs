using BsseCode._5._GameEntities.Objects.EnergyLoot;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.Pools.EnergyLootPool
{
    public class EnergyLootSpawner : MonoBehaviour
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
            var bullet = _poolController.GetPool<EnergyLoot>().GetElement();
            bullet.transform.position = _bulletSpawnPoint.transform.position;
        }
    }
}
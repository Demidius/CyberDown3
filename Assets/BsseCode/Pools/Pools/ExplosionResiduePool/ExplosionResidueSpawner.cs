using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ExplosionResiduePool
{
    public class ExplosionResidueSpawner : MonoBehaviour
    {

        private Transform _spawnPoint;
        private IPoolsBase _poolBase;

        [Inject]
        public void Construct(IPoolsBase poolBullet)
        {
            _poolBase = poolBullet;
        }

        public void Spawn(Vector2 position)
        {
            var element = _poolBase.ExplosionComponent.GetElement();
            element.transform.position = position;
        }
    }

}
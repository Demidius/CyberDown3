using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ExplosionResiduePool
{
    public class ExplosionResidueSpawner : MonoBehaviour
    {

        private Transform _spawnPoint;
        private IPoolController _poolBase;

        [Inject]
        public void Construct(IPoolController poolBullet)
        {
            _poolBase = poolBullet;
        }

        public void Spawn(Vector2 position)
        {
            var element = _poolBase.GetPool<ExplosionResidue>().GetElement();;
            element.transform.position = position;
        }
    }

}
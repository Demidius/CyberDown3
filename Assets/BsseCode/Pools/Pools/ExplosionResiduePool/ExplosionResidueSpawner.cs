using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ExplosionResiduePool
{
    public class ExplosionResidueSpawner : MonoBehaviour
    {

        private Transform _spawnPoint;
        private IPoolController _poolController;


        [Inject]
        public void Construct(IPoolController poolController)
        {
            _poolController = poolController;
        }


        public void Spawn(Vector2 position)
        {
            var element = _poolController.GetPool<ExplosionResidue>().GetElement();
            element.transform.position = position;
        }
    }

}
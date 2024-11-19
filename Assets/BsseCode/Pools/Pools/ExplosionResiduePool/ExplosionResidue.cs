using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ExplosionResiduePool
{
    public class ExplosionResidue : MonoBehaviour, IPoolsElement
    {
        private IPoolController _poolController;

        [Inject]
        public void Construct(IPoolController poolController)
        {
            _poolController = poolController;
        }

        public void Deactivate()
        {
            _poolController.GetPool<ExplosionResidue>().ReturnToPool(this);
        }
    }
}
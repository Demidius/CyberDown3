using UnityEngine;

namespace BsseCode.Pools.Pools.ExplosionResiduePool
{
    public class ExplosionResidue : MonoBehaviour, IPoolsElement
    {
        private IPoolsBase _poolsBase;

        public void SetParameters(IPoolsBase poolsBase)
        {
            _poolsBase = poolsBase;
        }

        public void Deactivate()
        {
            _poolsBase.ExplosionResidueComponent?.ReturnToPool(this);
        }
    }
}
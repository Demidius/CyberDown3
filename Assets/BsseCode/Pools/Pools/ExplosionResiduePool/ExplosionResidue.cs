using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ExplosionResiduePool
{
    public class ExplosionResidue : MonoBehaviour, IPoolsElement
    {
        private IPoolsBase _poolsBase;
        
        [Inject]
        public void Construct(IPoolsBase poolsBase)
        {
            _poolsBase = poolsBase;
        }

        public void Deactivate()
        {
            _poolsBase.ExplosionResidueComponent?.ReturnToPool(this);
        }
    }
}
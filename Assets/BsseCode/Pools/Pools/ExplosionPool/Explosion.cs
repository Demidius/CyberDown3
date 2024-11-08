using UnityEngine;

namespace BsseCode.Pools.Pools.ExplosionPool
{
    public class Explosion : MonoBehaviour, IPoolsElement
    {
        private IPoolsBase _poolsBase;

        public void SetParameters(IPoolsBase poolsBase)
        {
            _poolsBase = poolsBase;
        }

        public void Deactivate()
        {
            _poolsBase.ExplosionComponent?.ReturnToPool(this);
        }
    }

}
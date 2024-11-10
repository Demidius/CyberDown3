using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ExplosionPool
{
    public class Explosion : MonoBehaviour, IPoolsElement
    {
        private IPoolsBase _poolsBase;

        [Inject]
        public void Construct(IPoolsBase poolsBase)
        {
            _poolsBase = poolsBase;
        }

        public void Deactivate()
        {
            _poolsBase.ExplosionComponent?.ReturnToPool(this);
        }
    }

}
using UnityEngine;

namespace BsseCode.Pools.Pools.ShootFiresPool
{
    public class ShootFire : MonoBehaviour, IPoolsElement
    {
        private IPoolsBase _poolsBase;
       
        public void SetParameters(IPoolsBase poolsBase)
        {
            _poolsBase = poolsBase;
        }
        
        public void Deactivate()
        {
            _poolsBase.ShootFirePoolComponent?.ReturnToPool(this);
        }
    }
}

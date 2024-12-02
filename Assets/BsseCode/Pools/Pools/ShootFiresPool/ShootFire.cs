using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ShootFiresPool
{
    public class ShootFire : MonoBehaviour, IPoolsElement
    {
        private IPoolController _poolController;


        [Inject]
        public void Construct(IPoolController poolController)
        {
            _poolController = poolController;
        }

        
        public void Deactivate()
        {
            _poolController.ReturnToPool(this);
        }
    }
}
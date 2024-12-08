using BsseCode._2._Services.GlobalServices.Pools;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.ShootFire
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

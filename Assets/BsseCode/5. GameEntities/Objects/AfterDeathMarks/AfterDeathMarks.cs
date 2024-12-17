using BsseCode._2._Services.GlobalServices.Pools;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.AfterDeathMarks
{
    public class AfterDeathMarks : MonoBehaviour, IPoolsElement
    {
        private IPoolController _poolController;


        [Inject]
        public void Construct(IPoolController poolController)
        {
            _poolController = poolController;
        }


        public void Kill()
        {
            _poolController.ReturnToPool(this);
        }
    }
}
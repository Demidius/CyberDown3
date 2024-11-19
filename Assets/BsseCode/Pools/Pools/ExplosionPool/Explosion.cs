using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ExplosionPool
{
    public class Explosion : MonoBehaviour, IPoolsElement
    {
        private IPoolController _poolController;

        [Inject]
        public void Construct(IPoolController poolController)
        {
            _poolController = poolController;
        }

        public void Deactivate()
        {
            _poolController.GetPool<Explosion>().ReturnToPool(this);
        }
    }

}
using UnityEngine;

namespace _2_NewBaseCode.Level1._2_Level1Services.Pools
{
    public class PoolElement : MonoBehaviour, IPoolsElement
    {
        public void ReturnToPool()
        {
            var poolController = FindObjectOfType<PoolController>();
            poolController?.ReturnToPool(this);
        }
    }
}
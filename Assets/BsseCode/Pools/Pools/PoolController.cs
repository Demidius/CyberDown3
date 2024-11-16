using System.Collections.Generic;
using BsseCode.Services.Factory;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools
{
    public class PoolController : MonoBehaviour, IPoolController
    {
        [System.Serializable]
        private struct PoolData
        {
            public string PoolName;
            public MonoBehaviour Prefab;
        }

        [SerializeField] private List<PoolData> poolDataList;
        [SerializeField] private int baseSize = 10;

        private IFactoryComponent _factoryComponent;
        private Dictionary<string, object> _pools;

        [Inject]
        public void Construct(IFactoryComponent factoryComponent)
        {
            _factoryComponent = factoryComponent;
        }

        private void Awake()
        {
            _pools = new Dictionary<string, object>();
        }

        private void Start()
        {
            foreach (var poolData in poolDataList)
            {
                RegisterPool(poolData.PoolName, poolData.Prefab, baseSize);
            }
        }

        public void RegisterPool<T>(string poolName, T prefab, int size) where T : MonoBehaviour
        {
            Debug.Log($"Registering pool: {poolName}, Type: {typeof(T)}");
            if (_pools.ContainsKey(poolName))
            {
                Debug.LogWarning($"Pool with name {poolName} is already registered.");
                return;
            }

            var pool = new PoolComponent<T>(prefab, size, this.transform, _factoryComponent);
            _pools[poolName] = pool;
        }


        public PoolComponent<T> GetPool<T>(string poolName) where T : MonoBehaviour
        {
            if (_pools.TryGetValue(poolName, out var pool))
            {
                if (pool is PoolComponent<T> typedPool)
                {
                    Debug.Log($"Pool with name {poolName} found, Type: {typedPool.GetType()}");
                    return typedPool;
                }
                Debug.LogError($"Pool with name {poolName} found, but it has a different type: {pool.GetType()}");
                return null;
            }

            Debug.LogError($"Pool with name {poolName} not found.");
            return null;
        }
            
        
    }
}

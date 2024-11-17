using System;
using System.Collections.Generic;
using BsseCode.Services.Factory;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools
{
    public class PoolController : IPoolController
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
        private Dictionary<Type, object> _pools;

        [Inject] // в бутстрапе прокинуть через конструктор все ссылки. через [SerializeField] или скипт обж. Прокинуть префабы.
        public void Construct(IFactoryComponent factoryComponent)
        {
            _factoryComponent = factoryComponent;
        }

        private void Awake()
        {
            _pools = new Dictionary<Type, object>();
        }

        public void RegisterPool<T>(T prefab, int size) where T : MonoBehaviour
        {
            var type = typeof(T);
            Debug.Log($"Registering pool: {type}, Type: {typeof(T)}");
            if (_pools.ContainsKey(type))
            {
                Debug.LogWarning($"Pool with name {type} is already registered.");
                return;
            }

            var pool = new PoolComponent<T>(prefab, size, this.transform, _factoryComponent);
            _pools[type] = pool;
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

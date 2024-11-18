using System;
using System.Collections.Generic;
using System.Reflection;
using BsseCode.ScriptableObjects;
using BsseCode.Services.Factory;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools
{
    public class PoolController : MonoBehaviour, IPoolController
    {
        [SerializeField] private PoolsScriptableObject poolsConfig;
        [SerializeField] private int defaultPoolSize = 10;


        private IFactoryComponent _factoryComponent;
        private Dictionary<Type, object> poolRegistry;

        [Inject] 
        public void Construct(IFactoryComponent factoryComponent)
        {
            _factoryComponent = factoryComponent;
        }

        private void Awake()
        {
            poolRegistry = new Dictionary<Type, object>();
            RegisterPoolsFromConfig();
        }

        public void RegisterPool<T>(T prefab, int size) where T : MonoBehaviour
        {
            var type = typeof(T);
            if (poolRegistry.ContainsKey(type))
            {
                Debug.LogWarning($"Pool for type {type.Name} is already registered.");
                return;
            }

            var pool = new PoolComponent<T>(prefab, size, _factoryComponent);
            poolRegistry.Add(type, pool);
        }


        public PoolComponent<T> GetPool<T>() where T : MonoBehaviour
        {
            var type = typeof(T);
            if (poolRegistry.TryGetValue(type, out var pool))
            {
                if (pool is PoolComponent<T> typedPool)
                {
                    return typedPool;
                }
                return null;
            }
            return null;
        }

        private void RegisterPoolsFromConfig()
        {
            foreach (var poolConfig in poolsConfig.PoolPrefabs)
            {
                if (poolConfig.Prefab is MonoBehaviour monoBehaviourPrefab)
                {
                    RegisterPool(monoBehaviourPrefab, defaultPoolSize);
                }
                else
                {
                    Debug.LogWarning($"Invalid prefab in PoolPrefabs: {poolConfig.Description ?? "No Description"}");
                }
            }
        }
    }
}


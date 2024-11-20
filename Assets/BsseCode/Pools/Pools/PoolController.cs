using System;
using System.Collections.Generic;
using BsseCode.Pools.Pools.BulletPool;
using BsseCode.Services.Factory;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools
{
    public interface IPoolController
    {
        PoolComponent<T> GetPool<T>() where T : MonoBehaviour, IPoolsElement;
        void ReturnToPool<T>(T element) where T : MonoBehaviour, IPoolsElement;
    }

    public class PoolController : MonoBehaviour, IPoolController
    {
        [SerializeField] private PoolPrefabScObj PoolPrefabScObj;

        [SerializeField] private int startPoolSize = 5;

        public Dictionary<Type, object> PoolsDictionary { get; private set; }

        private IFactoryComponent _factoryComponent;

        [Inject]
        public void Construct(IFactoryComponent factoryComponent)
        {
            _factoryComponent = factoryComponent;
        }

        private void Awake()
        {
            PoolsDictionary = new Dictionary<Type, object>();
        }

        private void Start()
        {
            IterateListComponents();
        }

        private void IterateListComponents()
        {
            foreach (var poolElement in PoolPrefabScObj.PoolPrefabs)
            {
                var element = poolElement.GetComponent<IPoolsElement>();
                if (element == null)
                {
                    Debug.LogWarning($"Prefab {poolElement.name} does not implement IPoolsElement.");
                    continue;
                }

                var elementType = element.GetType();
                if (PoolsDictionary.ContainsKey(elementType))
                {
                    Debug.LogWarning($"Pool for type {elementType.Name} is already registered.");
                    continue;
                }

                PoolsDictionary[elementType] = InitializePool(poolElement, elementType);

               
            }
        }

        private object InitializePool(GameObject poolElement, Type elementType)
        {
            var prefab = poolElement.GetComponent(elementType) as MonoBehaviour;
            var poolType = typeof(PoolComponent<>).MakeGenericType(elementType);
            return Activator.CreateInstance(poolType, prefab, startPoolSize, this.transform, _factoryComponent);
        }

        // private PoolComponent<T> InitializePoolComponent<T>(T prefab, int size) where T : MonoBehaviour
        // {
        //     return new PoolComponent<T>(prefab, size, this.transform, _factoryComponent);
        // }
        
        public PoolComponent<T> GetPool<T>() where T : MonoBehaviour, IPoolsElement
        {
            var type = typeof(T);
            
            if (PoolsDictionary.TryGetValue(type, out var pool))
            {
                if (pool is PoolComponent<T> typedPool)
                {
                    return typedPool;
                }

                Debug.LogError($"Pool found for type {type.Name} is not of the expected type. Found type: {pool.GetType()}");
                return null;
            }

            Debug.LogError($"No pool registered for type {type.Name}.");
            return null;
        }
        
        public void ReturnToPool<T>(T element) where T : MonoBehaviour, IPoolsElement
        {
            var pool = GetPool<T>();
            if (pool != null)
            {
                pool.ReturnToPool(element);
            }
            else
            {
                Debug.LogError($"Cannot return element of type {typeof(T).Name} to pool. Pool not found.");
            }
        }
        
        
    }

   
}
using System;
using System.Collections.Generic;
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
        [SerializeField] private PoolPrefabScObj poolPrefabScObj;
        [SerializeField] private int startPoolSize = 5;

        private Dictionary<Type, object> _poolsDictionary;
        private IFactoryComponent _factoryComponent;

        [Inject]
        public void Construct(IFactoryComponent factoryComponent)
        {
            _factoryComponent = factoryComponent;
        }

        private void Awake()
        {
            _poolsDictionary = new Dictionary<Type, object>();
        }

        private void Start()
        {
            foreach (var poolElement in poolPrefabScObj.PoolPrefabs)
            {
                RegisterPool(poolElement);
            }
        }

        private void RegisterPool(GameObject poolElement)
        {
            var element = poolElement.GetComponent<IPoolsElement>();
            if (element == null) return;

            var elementType = element.GetType();
            if (_poolsDictionary.ContainsKey(elementType)) return;

            _poolsDictionary[elementType] = CreatePool(poolElement, elementType);
        }

        private object CreatePool(GameObject poolElement, Type elementType)
        {
            var prefab = poolElement.GetComponent(elementType) as MonoBehaviour;
            var poolType = typeof(PoolComponent<>).MakeGenericType(elementType);
            return Activator.CreateInstance(poolType, prefab, startPoolSize, transform, _factoryComponent);
        }

        public PoolComponent<T> GetPool<T>() where T : MonoBehaviour, IPoolsElement
        {
            var type = typeof(T);

            if (_poolsDictionary.TryGetValue(type, out var pool) && pool is PoolComponent<T> typedPool)
            {
                return typedPool;
            }

            return null;
        }

        public void ReturnToPool<T>(T element) where T : MonoBehaviour, IPoolsElement
        {
            var pool = GetPool<T>();
            pool?.ReturnToPool(element);
        }
    }
}

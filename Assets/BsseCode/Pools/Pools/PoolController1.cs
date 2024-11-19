using System;
using System.Collections.Generic;
using BsseCode.ScriptableObjects;
using BsseCode.Services.Factory;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools
{
    public class PoolController : MonoBehaviour, IPoolController
    {
        [SerializeField] private PoolsScriptableObject poolsConfig;

        private Dictionary<Type, object> _poolRegistry;

        private IFactoryComponent _factoryComponent;

        [Inject]
        public void Construct(IFactoryComponent factoryComponent)
        {
            _factoryComponent = factoryComponent;
        }

        private void Awake()
        {
            // Инициализация реестра
            _poolRegistry = new Dictionary<Type, object>();
        }

        private void Start()
        {
            // Регистрация пулов из ScriptableObject
            RegisterPoolsFromConfig();
        }

        private void RegisterPoolsFromConfig()
        {
            foreach (var poolConfig in poolsConfig.ListOfPrefabs)
            {
                // Получаем компонент, реализующий IPoolsElement
                var component = poolConfig.Prefab.GetComponent<IPoolsElement>();

                if (component == null)
                {
                    Debug.LogWarning($"Prefab {poolConfig.Prefab.name} does not have a component implementing IPoolsElement.");
                    continue;
                }

                var type = component.GetType();

                // Проверяем, что этот тип ещё не зарегистрирован
                if (_poolRegistry.ContainsKey(type))
                {
                    Debug.LogWarning($"Pool for type {type.Name} is already registered with prefab {poolConfig.Prefab.name}.");
                    continue;
                }

                // Создаём пул и регистрируем его
                var pool = CreatePool(type, poolConfig.Prefab);
                _poolRegistry.Add(type, pool);

                Debug.Log($"[PoolController] Registered pool for type {type.Name} with prefab {poolConfig.Prefab.name}.");
            }
        }

        private object CreatePool(Type type, GameObject prefab)
        {
            // Создаём пул через рефлексию
            var poolType = typeof(PoolComponent<>).MakeGenericType(type);
            var pool = Activator.CreateInstance(poolType, prefab.GetComponent(type), 10, _factoryComponent);
            return pool;
        }

        public T GetElementFromPool<T>() where T : Component
        {
            var type = typeof(T);

            if (_poolRegistry.TryGetValue(type, out var pool))
            {
                if (pool is PoolComponent<T> typedPool)
                {
                    return typedPool.GetElement();
                }
            }

            Debug.LogError($"[PoolController] No pool registered for type {type.Name}.");
            return null;
        }

        public void ReturnElementToPool<T>(T element) where T : Component
        {
            var type = typeof(T);

            if (_poolRegistry.TryGetValue(type, out var pool))
            {
                if (pool is PoolComponent<T> typedPool)
                {
                    typedPool.ReturnToPool(element);
                }
                else
                {
                    Debug.LogError($"[PoolController] Pool found for type {type.Name} is not of the correct type.");
                }
            }
            else
            {
                Debug.LogError($"[PoolController] No pool registered for type {type.Name}.");
            }
        }

        public GameObject GetPrefabForType<T>() where T : Component, IPoolsElement
        {
            var type = typeof(T);

            if (_poolRegistry.TryGetValue(type, out var pool))
            {
                if (pool is PoolComponent<T> typedPool)
                {
                    return typedPool.PrefabObject.gameObject; // Теперь работает
                }
            }

            Debug.LogError($"[PoolController] No prefab registered for type {type.Name}.");
            return null;
        }

        public void RegisterPool(Type type, GameObject prefab)
        {
            if (prefab == null)
            {
                Debug.LogError($"[PoolController] Cannot register null prefab for type {type.Name}.");
                return;
            }

            if (!typeof(IPoolsElement).IsAssignableFrom(type))
            {
                Debug.LogError($"[PoolController] Type {type.Name} does not implement IPoolsElement.");
                return;
            }

            if (_poolRegistry.ContainsKey(type))
            {
                Debug.LogWarning($"[PoolController] Pool for type {type.Name} is already registered.");
                return;
            }

            var pool = CreatePool(type, prefab);
            _poolRegistry.Add(type, pool);

            Debug.Log($"[PoolController] Registered pool for type {type.Name} with prefab {prefab.name}.");
        }

        public GameObject GetPrefabForType(Type type)
        {
            if (!typeof(IPoolsElement).IsAssignableFrom(type))
            {
                Debug.LogError($"[PoolController] Type {type.Name} does not implement IPoolsElement.");
                return null;
            }

            if (_poolRegistry.TryGetValue(type, out var pool))
            {
                if (pool is PoolComponent<Component> typedPool)
                {
                    return typedPool.PrefabObject.gameObject;
                }
            }

            Debug.LogError($"[PoolController] No prefab registered for type {type.Name}.");
            return null;
        }
    }
}

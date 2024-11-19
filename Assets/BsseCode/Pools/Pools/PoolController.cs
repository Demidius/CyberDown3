using System;
using System.Collections.Generic;
using System.Reflection;
using BsseCode.ScriptableObjects;
using BsseCode.Services.Factory;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools
{
    // public class PoolController : MonoBehaviour, IPoolController
    // {
    //     [SerializeField] private PoolsScriptableObject poolsConfig;
    //     [SerializeField] private int defaultPoolSize = 10;
    //     private Dictionary<Type, object> _poolRegistry;
    //
    //     private IFactoryComponent _factoryComponent;
    //
    //     [Inject]
    //     public void Construct(IFactoryComponent factoryComponent)
    //     {
    //         _factoryComponent = factoryComponent;
    //     }
    //
    //     private void Awake()
    //     {
    //         _poolRegistry = new Dictionary<Type, object>();
    //     }
    //
    //     private void Start()
    //     {
    //         RegisterPoolsFromConfig();
    //     }
    //
    //     public void RegisterPool<T>(T prefab, int size) where T : MonoBehaviour
    //     {
    //         
    //         var type = typeof(T);
    //         if (_poolRegistry.ContainsKey(type))
    //         {
    //             Debug.LogWarning($"Pool for type {type.Name} is already registered.");
    //             return;
    //         }
    //
    //         var pool = new PoolComponent<T>(prefab, size, _factoryComponent);
    //         _poolRegistry.Add(type, pool);
    //     }
    //
    //     
    //     public void RegisterPool(Type type, int size)
    //     {
    //         if (_poolRegistry.ContainsKey(type))
    //         {
    //             Debug.LogWarning($"Pool for type {type.Name} is already registered.");
    //             return;
    //         }
    //
    //         var prefab = poolsConfig.GetPrefabByType(type);
    //         if (prefab == null)
    //         {
    //             Debug.LogError($"No prefab found for type {type.Name}");
    //             return;
    //         }
    //
    //         try
    //         {
    //             var pool = Activator.CreateInstance(
    //                 typeof(PoolComponent<>).MakeGenericType(type),
    //                 prefab, size, _factoryComponent);
    //             _poolRegistry.Add(type, pool);
    //         }
    //         catch (Exception ex)
    //         {
    //             Debug.LogError($"Failed to create pool for type {type.Name}: {ex.Message}");
    //         }
    //     }
    //
    //     public PoolComponent<T> GetPool<T>() where T : MonoBehaviour
    //     {
    //         var type = typeof(T);
    //         if (_poolRegistry.TryGetValue(type, out var pool))
    //         {
    //             if (pool is PoolComponent<T> typedPool)
    //             {
    //                 return typedPool;
    //             }
    //
    //             return null;
    //         }
    //
    //         return null;
    //     }
    //
    //     private void RegisterPoolsFromConfig()
    //     {
    //         foreach (var poolConfig in poolsConfig.PoolPrefabs)
    //         {
    //             var component = poolConfig.Prefab.GetComponent<IPoolsElement>();
    //            
    //             var type = component.GetType();
    //             
    //             if (type.IsAssignableTo(typeof(MonoBehaviour)))
    //             {
    //                 // Регистрируем пул с указанным типом
    //                 RegisterPool(type, defaultPoolSize);
    //                 Debug.Log($"Registered pool for type: {type.Name}");
    //             }
    //             else
    //             {
    //                 Debug.LogWarning($"Component implementing IPoolsElement is not a MonoBehaviour: {poolConfig.Description ?? "No Description"}");
    //             }
    //         }
    //     }
    // }
}
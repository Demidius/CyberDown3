using System;
using System.Collections.Generic;
using BsseCode.ScriptableObjects;
using BsseCode.Services.Factory;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools
{
    public class PoolController2 : MonoBehaviour, IPoolController2
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
            _poolRegistry = new Dictionary<Type, object>();
        }

        private void RegistrationPools()
        {
            foreach (var listElement  in poolsConfig.ListOfPrefabs)
            {
                var type = listElement.Prefab.GetComponent<IPoolsElement>();
                
                var pool = CreatePool(type, poolConfig.Prefab);
                
                _poolRegistry.Add(type, pool);
            }
        }




    }

    public interface IPoolController2
    {
    }
}
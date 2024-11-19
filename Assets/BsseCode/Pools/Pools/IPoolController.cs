using System;
using UnityEngine;

namespace BsseCode.Pools.Pools
{
    public interface IPoolController
    {
        
            GameObject GetPrefabForType<T>() where T : Component, IPoolsElement;
            void RegisterPool(Type type, GameObject prefab);
            GameObject GetPrefabForType(Type type);
        
    }
}
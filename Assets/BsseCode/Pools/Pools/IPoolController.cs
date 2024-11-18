using BsseCode.Pools.Pools.AmmoLootPool;
using BsseCode.Pools.Pools.BulletPool;
using BsseCode.Pools.Pools.EnemesPool;
using BsseCode.Pools.Pools.ExplosionPool;
using BsseCode.Pools.Pools.ExplosionResiduePool;
using BsseCode.Pools.Pools.ShootFiresPool;
using UnityEngine;

namespace BsseCode.Pools.Pools
{
    public interface IPoolController
    {
     
        void RegisterPool<T>( T prefab, int size) where T : MonoBehaviour;

       
        PoolComponent<T> GetPool<T>() where T : MonoBehaviour;
    }
}
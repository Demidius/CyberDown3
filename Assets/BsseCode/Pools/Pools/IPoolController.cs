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
        /// <summary>
        /// Регистрирует новый пул с заданным именем.
        /// </summary>
        /// <typeparam name="T">Тип объекта в пуле.</typeparam>
        /// <param name="poolName">Имя пула.</param>
        /// <param name="prefab">Префаб объекта.</param>
        /// <param name="size">Размер пула.</param>
        void RegisterPool<T>(string poolName, T prefab, int size) where T : MonoBehaviour;

        /// <summary>
        /// Возвращает пул по имени.
        /// </summary>
        /// <typeparam name="T">Тип объекта в пуле.</typeparam>
        /// <param name="poolName">Имя пула.</param>
        /// <returns>Пул объекта указанного типа.</returns>
        PoolComponent<T> GetPool<T>(string poolName) where T : MonoBehaviour;
    }
}
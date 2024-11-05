using BsseCode.Pools.Enemes;
using BsseCode.Pools.Pools;
using BsseCode.Pools.Weapons.Bullet;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace BsseCode.Installers
{
    public class PoolInstaller : MonoInstaller
    {
        [SerializeField] private GameObject poolEnemy1Prefab; 
        [SerializeField] private GameObject poolsBasePrefab; 

        public override void InstallBindings()
        {
             #region PoolEnemy
            
            Container.Bind<PoolComponent<Enemy>>()
                .AsTransient();
                
            Container.Bind<IPoolEnemy1>()
                .To<PoolEnemy1>()
                .FromComponentInNewPrefab(poolEnemy1Prefab)
                .AsSingle();
            
            #endregion
            
            #region PoolBullet
            
            Container.Bind<PoolComponent<Bullet>>()
                .AsTransient();
                
            Container.Bind<IPoolsBase>()
                .To<PoolsBase>()
                .FromComponentInNewPrefab(poolsBasePrefab)
                .AsSingle();
            
           
            #endregion
            
           
            Debug.Log("Pools installed");
        }
    }
}
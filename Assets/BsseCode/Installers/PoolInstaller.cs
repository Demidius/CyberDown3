using BsseCode.Pools.Pools;
using BsseCode.Pools.Pools.BulletPool;
using BsseCode.Pools.Pools.EnemesPool;
using BsseCode.Pools.Pools.ExplosionPool;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace BsseCode.Installers
{
    public class PoolInstaller : MonoInstaller
    {
        [SerializeField] private GameObject poolsBasePrefab; 

        public override void InstallBindings()
        {
             #region PoolEnemy
            
            Container.Bind<PoolComponent<Enemy>>()
                .AsTransient();
            
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
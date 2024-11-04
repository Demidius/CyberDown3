using BsseCode.Enemes;
using BsseCode.Weapons.Bullet;
using UnityEngine;
using Zenject;

namespace BsseCode.Installers
{
    public class PoolInstaller : MonoInstaller
    {
        [SerializeField] private GameObject poolEnemy1Prefab; 
        [SerializeField] private GameObject poolBulletPrefab; 

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
                
            Container.Bind<IPoolBullet>()
                .To<PoolBullet>()
                .FromComponentInNewPrefab(poolBulletPrefab)
                .AsSingle();
            
           
            #endregion
            
           
            Debug.Log("Pools installed");
        }
    }
}
using BsseCode.Services.Factory;
using BsseCode.Weapons.Bullet;
using UnityEngine;
using Zenject;

namespace BsseCode.Installers
{
    public class PoolInstaller : MonoInstaller
    {
        [SerializeField] private GameObject poolBulletPrefab; 

        public override void InstallBindings()
        {
            #region Pool
            
            Container.Bind<PoolComponent<Bullet>>()
                .AsSingle();
                
            Container.Bind<IPoolBullet>()
                .To<PoolBullet>()
                .FromComponentInNewPrefab(poolBulletPrefab)
                .AsCached();
            
            Debug.Log("Pool installed");
            #endregion
        }
    }
}
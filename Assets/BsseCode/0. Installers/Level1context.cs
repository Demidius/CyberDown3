using BsseCode._5._GameEntities.PlayerModule;
using BsseCode._5._GameEntities.PlayerModule.Components;
using UnityEngine;
using Zenject;

namespace BsseCode._0._Installers
{
    public class Level1Context : MonoInstaller
    {
        [SerializeField] private Player _playerPrefab;
        
        public override void InstallBindings()
        {            
            RegisterPlayerModule();
        }
        private void RegisterPlayerModule()
        {
            Container.Bind<IPlayerModule>().To<PlayerModule>().AsSingle();
            Container.Bind<IPlayer>().To<Player>().FromComponentInNewPrefab(_playerPrefab).AsSingle();
            Container.Bind<IBulletSpawnPoint>().To<BulletSpawnPoint>().FromComponentInNewPrefab(_playerPrefab).AsSingle();
        }
    }
}
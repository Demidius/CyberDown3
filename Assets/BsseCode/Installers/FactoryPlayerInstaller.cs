using BsseCode.Hero.Spawner;
using BsseCode.Services.Factory;
using UnityEngine;
using Zenject;



namespace BsseCode.Installers
{
    public class FactoryPlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<PlayerFactory>()
                .AsSingle()
                .WithArguments(_playerPrefab);  
            
            
            Container.Bind<IFactoryComponent>()
                .To<FactoryComponent>()
                .AsTransient();
        }
    }
}
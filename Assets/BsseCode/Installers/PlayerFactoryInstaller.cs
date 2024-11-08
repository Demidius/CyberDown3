using BsseCode.Hero.Spawner;
using BsseCode.Services.Factory;
using UnityEngine;
using Zenject;

namespace BsseCode.Installers
{
    public class PlayerFactoryInstaller : MonoInstaller
    {
       [SerializeField] private GameObject _playerPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerFactory>().FromComponentInHierarchy().AsSingle();
                
            Container.Bind<IFactoryComponent>().To<FactoryComponent>().AsSingle();
        }
    }
}
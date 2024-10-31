using BsseCode.Services.Factory;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;


namespace BsseCode.Installers
{
    public class FactoryPlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab; // Префаб игрока

        public override void InstallBindings()
        {
            // Привязываем фабрику игрока, передавая префаб
            Container.Bind<PlayerFactory>()
                .AsSingle()
                .WithArguments(_playerPrefab);
        }
    }
}
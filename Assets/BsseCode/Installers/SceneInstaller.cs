using BsseCode.Services.Factory;
using BsseCode.Services.PlayerMouseService;
using UnityEngine;
using Zenject;

namespace BsseCode.Installers
{
    public class SceneInstaller  : MonoInstaller
    {
        // private Camera _camera;
        // private PlayerFactory _playerFactory;
        //
        // [Inject]
        // public void Construct(Camera camera, PlayerFactory playerFactory)
        // {
        //     _camera = camera;
        //     _playerFactory = playerFactory; 
        // }
        //
        // public override void InstallBindings()
        // {
        //
        //     Container.Bind<IPlayerMouseService>().To<PlayerMouseService>()
        //         .AsSingle()
        //         .WithArguments(_camera, _playerFactory);
        // }
    }
}
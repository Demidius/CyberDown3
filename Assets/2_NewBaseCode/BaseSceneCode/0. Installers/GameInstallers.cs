using _2_NewBaseCode.BaseSceneCode._1._GameMachine;
using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.Coroutines;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.Addressable;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.Addressable.NewBaseCode._2._Services.Addressable;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler;
using _2_NewBaseCode.BaseSceneCode._3._UI._1.Controllers;
using _2_NewBaseCode.BaseSceneCode._4._Audio;
using _2_NewBaseCode.BaseSceneCode._4._Audio.Data;
using _2_NewBaseCode.BaseSceneCode._4._Audio.Managers;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._0._Installers
{
    public class GameInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterServices();
            RegisterAddressable();
            RegisterStateMachine();
            RegisterUiControllers();
            RegisterAudioModule();
            RegisterCamera();
            
        }

        private void RegisterCamera()
        {
            Container.Bind<ICameraHandler>().To<CameraHandler>().FromComponentInHierarchy().AsSingle();
        }

        private void RegisterServices()
        {
            Container.Bind<ICoroutineGlobalService>().To<CoroutineGlobalService>().AsSingle();
            Container.Bind<CoroutineRunner>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void RegisterAddressable()
        {
            Container.Bind<IAddressableLoader>().To<AddressableLoader>().FromComponentInHierarchy().AsSingle();
            
        }

        private void RegisterAudioModule()
        {
            Container.Bind<AudioTracksBase>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IAudioManager>().To<AudioManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IMusicController>().To<MusicController>().FromComponentInHierarchy().AsSingle();
            
            
        }

        private void RegisterUiControllers()
        {
            Container.Bind<IMenuPanelsController>().To<MenuPanelsController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ILoadPanelController>().To<LoadPanelController>().FromComponentInHierarchy().AsSingle();
            // Container.Bind<IMenuButtonsController>().To<MenuButtonsController>().FromComponentInHierarchy().AsSingle();

        }
            

        private void RegisterStateMachine()
        {
            Container.Bind<IGameMachineModule>().To<GameMachineModule>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<ILevelLoadingController>().To<LevelLoadingController>().FromComponentInHierarchy().AsSingle().NonLazy();
            
        }
    }
}
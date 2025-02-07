using _2_NewBaseCode.BaseSceneCode._1_GameMachine;
using _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices.Coroutines;
using _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices.UnivercialUtils;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.Addressable;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.Addressable.NewBaseCode._2._Services.Addressable;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.CameraHandler;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.TimeModule;
using _2_NewBaseCode.BaseSceneCode._3._UI._1.Controllers;
using _2_NewBaseCode.BaseSceneCode._4._Audio;
using _2_NewBaseCode.BaseSceneCode._4._Audio.Data;
using _2_NewBaseCode.BaseSceneCode._4._Audio.Managers;
using _2_NewBaseCode.BaseSceneCode.PlayerPrefabManeger;
using _2_NewBaseCode.Level1._2_Level1Services.Factory;
using Zenject;


namespace _2_NewBaseCode.BaseSceneCode._0._Installers
{
    public class GameInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterCamera();
            RegisterInputService();
            RegisterUiControllers();
            
            RegisterServices();
            
            RegisterAddressable();
            RegisterAudioModule();
            
            RegisterStateMachine();
            
            Container.Bind<IFactory1>().To<Factory1>().AsSingle();
        }

        private void RegisterCamera()
        {
            Container.Bind<ICameraHandler>().To<CameraHandler>().FromComponentInHierarchy().AsSingle();
        }

        private void RegisterInputService()
        {
            Container.Bind<IInputController>().To<InputController>().FromComponentInHierarchy().AsSingle();
        }

        private void RegisterUiControllers()
        {
            Container.Bind<IMenuPanelsController>().To<MenuPanelsController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ILoadPanelController>().To<LoadPanelController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IPausePanelController>().To<PausePanelController>().FromComponentInHierarchy().AsSingle();
        }

        private void RegisterServices()
        {
            Container.Bind<ITimeManager>().To<TimeManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ICoroutineGlobalService>().To<CoroutineGlobalService>().AsSingle();
            Container.Bind<CoroutineRunner>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<IPlayerPrefabsDate>().To<PlayerPrefabsDate>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IPositionUpdateService>().To<PositionUpdateService>().AsSingle();
            // Container.Bind<PrefabsBase>().FromComponentInHierarchy().AsSingle();

        }

        private void RegisterAddressable()
        {
            Container.Bind<IAddressableLoader>().To<AddressableLoader>().FromComponentInHierarchy().AsSingle();
        }

        private void RegisterAudioModule()
        {
            Container.Bind<IAudioManager>().To<AudioManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<AudioTracksBase>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IMusicController>().To<MusicController>().FromComponentInHierarchy().AsSingle();
        }


        private void RegisterStateMachine()
        {
            Container.Bind<IGameMachineModule>().To<GameMachineModule>().FromComponentInHierarchy().AsSingle().NonLazy();
            // Container.Bind<ILevelLoadingController>().To<LevelLoadingController>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<IStateSwitcher>().To<StateSwitcher>().FromComponentInHierarchy().AsSingle();

        }
    }
}
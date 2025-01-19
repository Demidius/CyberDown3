using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.BaseSceneService;
using BsseCode._2._Services.GlobalServices.Addressable;
using BsseCode._2._Services.GlobalServices.BeaconHandler;
using BsseCode._2._Services.GlobalServices.Coroutines;
using BsseCode._2._Services.GlobalServices.Factory;
using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.PlayerHandlerFl;
using BsseCode._2._Services.GlobalServices.Pools;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices.BulletCounter;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._2._Services.LevelServices.TimerLevel;
using BsseCode._2._Services.ServiceLocator;
using BsseCode._3._SupportCode.RandomNumder;
using BsseCode._4._UI;
using BsseCode._5._GameEntities.UnivercialUtils;
using Cinemachine;
using UnityEngine;
using Zenject;


namespace BsseCode._0._Installers
{
    public class GameStartInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterCoroutines();
            RegisterAudioServices();
            RegisterServicesLocaters();
            RegisterMainServices();
            RegisterCameraServices();
            RegisterStateMachine();
        }

        private void RegisterServicesLocaters()
        {
            // Container.Bind<ITimeModule>().To<ITimeModule>().FromComponentInHierarchy().AsSingle();
            // Container.Bind<IUIServiceLocator>().To<UIServiceLocator>().AsSingle();
            // Container.Bind<IManagersServiceLocator>().To<ManagersServiceLocator>().AsSingle();
            // Container.Bind<IReusableServiceLocator>().To<ReusableServiceLocator>().AsSingle();
            // Container.Bind<ICameraServiceLocator>().To<CameraServiceLocator>().AsSingle();
            // Container.Bind<IAudioServicesLocator>().To<AudioServiceLocator>().AsSingle();
            // Container.Bind<PlayerHandler>().FromComponentInHierarchy().AsSingle();
        }

        private void RegisterStateMachine()
        {
            Container.Bind<IGameMachineModule>().To<GameMachineModule>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void RegisterMainServices()
        {
            // Container.Bind<IFactoryComponent>().To<FactoryComponent>().AsSingle();
            // Container.Bind<IRandomizerService>().To<RandomizerService>().AsSingle();
            //
            // Container.Bind<IInputGlobalService>().To<PcInputGlobalService>().AsSingle();
            // Container.Bind<UIController>().FromComponentInHierarchy().AsSingle().NonLazy();
            // Container.Bind<IAddressableLoader>().To<AddressableLoader>().FromComponentInHierarchy().AsSingle();
            //
            // Container.Bind<IUpdateService>().To<UpdateService>().FromComponentInHierarchy().AsSingle();
        }
      

        private void RegisterCameraServices()
        {
            // Container.Bind<CinemachineVirtualCamera>().FromComponentInHierarchy().AsSingle();
            // Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
        }

        private void RegisterAudioServices()
        {
            // Container.Bind<AudioTracksBase>().FromComponentInHierarchy().AsSingle();
            // Container.Bind<AudioManager>().FromComponentInHierarchy().AsSingle();
        }

        private void RegisterCoroutines()
        {
            // var coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            // DontDestroyOnLoad(coroutineRunner);
            // Container.Bind<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
            // Container.Bind<ICoroutineGlobalService>().To<CoroutineGlobalService>().AsSingle();
        }
    }
}
using BaseCode2._2._Services.Addressable;
using BaseCode2._2._Services.Coroutines;
using BaseCode2._6._Audio;
using BaseCode2._6._Audio.Data;
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.GlobalServices.BeaconHandler;
using BsseCode._2._Services.GlobalServices.Factory;
using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.Pools;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices.BulletCounter;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._2._Services.LevelServices.TimerLevel;
using BsseCode._2._Services.ServiceLocator;
using BsseCode._2._Services.UpdateManeger;
using BsseCode._3._SupportCode.RandomNumder;
using BsseCode._4._UI;
using BsseCode._5._GameEntities.PlayerModule;
using BsseCode._5._GameEntities.PlayerModule.Components;
using BsseCode._5._GameEntities.PlayerModule.PlayerHandlerFl;
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
            RegisterSpecializedServices();
            RegisterServicesLocaters();
            RegisterReusableServices();
            RegisterCameraServices();
            RegisterGameManagers();
            RegisterStateMachine();
            RegisterUpdateService();
        }

       

        private void RegisterServicesLocaters()
        {
            Container.Bind<IUIServiceLocator>().To<UIServiceLocator>().AsSingle();
            Container.Bind<IManagersServiceLocator>().To<ManagersServiceLocator>().AsSingle();
            Container.Bind<IReusableServiceLocator>().To<ReusableServiceLocator>().AsSingle();
            Container.Bind<ICameraServiceLocator>().To<CameraServiceLocator>().AsSingle();
            Container.Bind<IAudioServicesLocator>().To<AudioServiceLocator>().AsSingle();
        }

        private void RegisterStateMachine()
        {
            Container.Bind<GameMachineStarter>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

        private void RegisterGameManagers()
        {
            Container.Bind<BeaconHandler>().FromComponentInHierarchy().AsSingle();
            Container.Bind<KillsController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IEnergyCounter>().To<EnergyCounter>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ResultsManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerHandler>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ITimerLevel>().To<TimerLevel>().AsSingle();
        }

        private void RegisterReusableServices()
        {
            Container.Bind<IFactoryComponent>().To<FactoryComponent>().AsSingle();
            Container.Bind<IRandomizerService>().To<RandomizerService>().AsSingle();
            Container.Bind<PositionUpdateService>().AsSingle();
            Container.Bind<IPoolController>().To<PoolController>().FromComponentInHierarchy().AsSingle();
        }

        private void RegisterSpecializedServices()
        {
            Container.Bind<IInputGlobalService>().To<PcInputGlobalService>().AsSingle();
            Container.Bind<UIController>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<ITimeGlobalService>().To<TimeGlobalService>().AsSingle();
            Container.Bind<TimeController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IAddressableLoader>().To<AddressableLoader>().FromComponentInHierarchy().AsSingle();
        }

        private void RegisterUpdateService()
        {
            var updateManegerBech = new GameObject("UpdateManegerBech").AddComponent<UpdateManeger>();
            DontDestroyOnLoad(updateManegerBech);
            Container.Bind<IUpdateManeger>().To<UpdateManeger>().FromInstance(updateManegerBech).AsSingle();
        }

        private void RegisterCameraServices()
        {
            Container.Bind<CinemachineVirtualCamera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
        }

        private void RegisterAudioServices()
        {
            Container.Bind<AudioTracksBase>().FromComponentInHierarchy().AsSingle();
            Container.Bind<AudioManager>().FromComponentInHierarchy().AsSingle();
        }

        private void RegisterCoroutines()
        {
            var coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(coroutineRunner);
            Container.Bind<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
            Container.Bind<ICoroutineGlobalService>().To<CoroutineGlobalService>().AsSingle();
        }
    }
}
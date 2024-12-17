using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.GlobalServices.Addressable;
using BsseCode._2._Services.GlobalServices.Coroutines;
using BsseCode._2._Services.GlobalServices.Factory;
using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.PlayerHandler;
using BsseCode._2._Services.GlobalServices.Pools;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices.BulletCounter;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._2._Services.LevelServices.TimerLevel;
using BsseCode._3._SupportCode.RandomNumder;
using BsseCode._4._UI;
using BsseCode._5._GameEntities.UnivercialUtils;
using BsseCode._6._Audio.Data;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace BsseCode._0._Installers
{
    public class GameStartInstaller : MonoInstaller
    {
        public GameObject resultsManagerPrefab;
        public GameMachineStarter gameMachineStarter;
        public AudioTracksBase audioManagerPrefab;
        public KillsController killsControllerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<IFactoryComponent>().To<FactoryComponent>().AsSingle();
            Container.Bind<GameMachineStarter>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<UIController>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.Bind<ITimeGlobalService>().To<TimeGlobalService>().AsSingle();
            Container.Bind<IRandomizerService>().To<RandomizerService>().AsSingle();


            #region Coroutine

            var coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(coroutineRunner);
            Container.Bind<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
            Container.Bind<ICoroutineGlobalService>().To<CoroutineGlobalService>().AsSingle();

            #endregion

            Container.Bind<ResultsManager>().FromComponentInNewPrefab(resultsManagerPrefab).AsSingle().NonLazy();


            Container.Bind<AudioTracksBase>().FromComponentInNewPrefab(audioManagerPrefab).AsSingle();


            #region Services

            Container.Bind<IInputGlobalService>().To<PcInputGlobalService>().AsSingle();
            Container.Bind<IAddressableLoader>().To<AddressableLoader>().FromComponentInHierarchy().AsSingle();

            Container.Bind<PositionUpdateService>().AsSingle();
            Container.Bind<KillsController>().FromComponentInNewPrefab(killsControllerPrefab).AsSingle();

            #endregion

            #region Mechanics

            Container.Bind<IEnergyCounter>().To<EnergyCounter>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ITimerLevel>().To<TimerLevel>().AsSingle();

            //Container.Bind<ResultsManager>().FromComponentInHierarchy().AsSingle();

            #endregion


            #region Camera

            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CinemachineVirtualCamera>().FromComponentInHierarchy().AsSingle();

            #endregion


            Container.Bind<PlayerHandler>().FromComponentInHierarchy().AsSingle();

            Container.Bind<IPoolController>().To<PoolController>().FromComponentInHierarchy().AsSingle();

            Container.Bind<TimeController>().FromComponentInHierarchy().AsSingle();
        }
    }
}
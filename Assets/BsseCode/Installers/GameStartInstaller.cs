using BsseCode.Hero.Spawner;
using BsseCode.Mechanics.BulletCounter;
using BsseCode.Mechanics.GameResults;
using BsseCode.Mechanics.TimerLevel;
using BsseCode.Pools.Pools;
using BsseCode.Pools.Pools.EnemesPool;
using BsseCode.Services;
using BsseCode.Services.Coroutines;
using BsseCode.Services.Factory;
using BsseCode.Services.InputFol;
using BsseCode.Services.PlayerMouseService;
using BsseCode.Services.TimeProvider;
using Cinemachine;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace BsseCode.Installers
{
    public class GameStartInstaller : MonoInstaller
    {
        [SerializeField] private GameObject poolsBasePrefab;

        public override void InstallBindings()
        {
            #region Services

            Container.Bind<IInputService>().To<PcInputService>().AsSingle();
            Container.Bind<IPlayerMouseService>().To<PlayerMouseService>().AsSingle();
            Container.Bind<ITimeService>().To<TimeService>().AsSingle();
            Container.Bind<MoveService>().AsSingle();

            #endregion

            #region Mechanics

            Container.Bind<IBulletCounter>().To<BulletCounter>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ITimerLevel>().To<TimerLevel>().AsSingle();
            Container.Bind<ResultsManager>().FromComponentInHierarchy().AsSingle();

            #endregion


            #region Camera

            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CinemachineVirtualCamera>().FromComponentInHierarchy().AsSingle();

            #endregion

            Container.Bind<PlayerFactory>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IFactoryComponent>().To<FactoryComponent>().AsSingle();

            Container.Bind<IPoolsBase>().To<PoolsBase>().FromComponentInNewPrefab(poolsBasePrefab).AsSingle();
        }
    }
}
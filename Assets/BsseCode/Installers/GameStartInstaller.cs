using BsseCode.Mechanics.BulletCounter;
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
       

        public override void InstallBindings()
        {
            #region Services
            Container.Bind<IInputService>().To<PcInputService>().AsSingle();
            Container.Bind<IPlayerMouseService>().To<PlayerMouseService>().AsSingle();
            Container.Bind<ITimeService>().To<TimeService>().AsSingle();
            Container.Bind<MoveService>().AsTransient();
            #endregion

            #region StateMachine

            Container.Bind<GameStateMachine.GameStateMachine>().AsSingle().NonLazy();

            #endregion
            
            #region Coroutine

            var coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(coroutineRunner);
            Container.Bind<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
            Container.Bind<ICoroutineService>().To<CoroutineService>().AsSingle();

            #endregion

            #region Mechanics

            Container.Bind<IBulletCounter>().To<BulletCounter>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ITimerLevel>().To<TimerLevel>().AsSingle();
           // Container.Bind<IFactoryComponent>().To<FactoryComponent>().AsSingle();

            #endregion

            


           // Container.Bind<PlayerFactoryInstaller>().FromComponentInHierarchy().AsSingle();

         //   Container.Bind<IFactoryComponent>().To<FactoryComponent>().AsSingle();

        
            
            
        }
    }
}
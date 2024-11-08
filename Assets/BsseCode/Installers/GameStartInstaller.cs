using BsseCode.Mechanics;
using BsseCode.Mechanics.BulletCounter;
using BsseCode.Mechanics.TimerLevel;
using BsseCode.Services.Coroutines;
using BsseCode.Services.InputFol;
using BsseCode.Services.PlayerMouseService;
using UnityEngine;
using Zenject;

namespace BsseCode.Installers
{
    public class GameStartInstaller : MonoInstaller
    {
      
        public override void InstallBindings()
        {
            #region Services
            Container.Bind<IInputService>().To<PcInputService>().AsSingle();
            Container.Bind<IPlayerMouseService>().To<PlayerMouseService>().AsSingle();
          
            
            var coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(coroutineRunner);
            Container.Bind<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
            Container.Bind<ICoroutineService>().To<CoroutineService>().AsSingle();
           
            #endregion

            #region StateMachine
            Container.Bind<GameStateMachine.GameStateMachine>().AsSingle().NonLazy();

            #endregion
            
            #region Mechanics
            
            Container.Bind<IBulletCounter>().To<BulletCounter>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ITimerLevel>().To<TimerLevel>().AsSingle();
            
            #endregion
        }
    }
}
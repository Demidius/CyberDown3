using BsseCode.GameStateMachineFolder;
using BsseCode.Services.Coroutines;
using BsseCode.Services.InputFol;
using BsseCode.Services.PlayerMouseService;
using BsseCode.Services.TimerLevel;
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
            Container.Bind<ITimerWrorld>().To<TimerWrorld>().AsSingle();
            
            var coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(coroutineRunner);
            Container.Bind<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
            Container.Bind<ICoroutineService>().To<CoroutineService>().AsSingle();
           
            #endregion

            #region StateMachine
            Container.Bind<GameStateMachine>().AsSingle().NonLazy();

            #endregion
        }
    }
}
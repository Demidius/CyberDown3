using BsseCode.Pools.Pools;
using BsseCode.Services;
using BsseCode.Services.Coroutines;
using BsseCode.Services.InputFol;
using BsseCode.Services.PlayerMouseService;
using BsseCode.Services.RandomNumder;
using BsseCode.Services.TimeProvider;
using BsseCode.StateMachines.GameStateMachine;
using BsseCode.StateMachines.GameStateMachine.States;
using UnityEngine;
using Zenject;

namespace BsseCode.Installers
{
    public class ProjectInstallers : MonoInstaller
    {
       public override void InstallBindings()
        {
           

            #region StateMachine

            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<MainMenuState>().AsSingle();
            Container.Bind<LoadLevelState>().AsTransient();
            Container.Bind<GameplayState>().AsSingle();
            Container.Bind<PauseState>().AsSingle();
            Container.Bind<GameOverState>().AsSingle();

            #endregion

            #region Coroutine

            var coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(coroutineRunner);
            Container.Bind<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
            Container.Bind<ICoroutineService>().To<CoroutineService>().AsSingle();
            Container.Bind<IRandomizerService>().To<RandomizerService>().AsSingle();

            #endregion

           
        }
    }
}
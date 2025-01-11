using BaseCode2._1.StateMachine.GameStates;
using BaseCode2._1.StateMachine.Logic;
using BaseCode2._2._Services.Addressable;
using BaseCode2._2._Services.Coroutines;
using UnityEngine;
using Zenject;

namespace BaseCode2._0._Installers
{
    public class BaseSceneContext : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterStateMachine();
            RegisterCoroutines();
            RegisterServices();
        }

        private void RegisterStateMachine()
        {
            Container.Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .FromComponentsInHierarchy()
                .AsSingle();

            Container.Bind<Base_BootstrapState>().AsSingle();
            Container.Bind<Base_MainMenuState>().AsSingle();
            Container.Bind<Base_LoadingState>().AsSingle();

            Container.Bind<Level_FinishState>().AsSingle();
            Container.Bind<Level_GameplayState>().AsSingle();
            Container.Bind<Level_PauseState>().AsSingle();
            Container.Bind<Level_ResetState>().AsSingle();
            Container.Bind<Level_WindowState>().AsSingle();
        }

        private void RegisterCoroutines()
        {
            var coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(coroutineRunner);
            Container.Bind<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
            Container.Bind<ICoroutineGlobalService>().To<CoroutineGlobalService>().AsSingle();
        }

        private void RegisterServices()
        {
            Container.Bind<IAddressableLoader>().To<AddressableLoader>().FromComponentInHierarchy().AsSingle();
        }
    }
}
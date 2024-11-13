using BsseCode.Audio;
using BsseCode.Mechanics.GameResults;
using BsseCode.Services.Coroutines;
using BsseCode.Services.RandomNumder;
using BsseCode.StateMachines.GameStateMachine;
using BsseCode.StateMachines.GameStateMachine.States;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace BsseCode.Installers
{
    public class ProjectInstallers : MonoInstaller
    {
        
        public GameObject resultsManagerPrefab;
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

            Container.Bind<ResultsManager>().FromComponentInNewPrefab(resultsManagerPrefab).AsSingle().NonLazy();       
            
            #region Sound
            
            Container.Bind<ISoundsExplorer>().To<SoundsExplorer>().AsSingle();
          
            var soundStorage = Resources.Load<SoundStorage>("SoundStorage");
        
            if (soundStorage == null)
            {
                Debug.LogError("SoundStorage.asset не найден в папке Resources!");
            }
        
            Container.Bind<SoundStorage>().FromInstance(soundStorage).AsSingle();
            #endregion
            
          
        }
    }
}
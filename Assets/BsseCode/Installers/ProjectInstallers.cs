using BsseCode.Audio;
using BsseCode.Audio.AudioSourcesHandlers;
using BsseCode.Mechanics.GameResults;
using BsseCode.Services.Coroutines;
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

        public GameObject resultsManagerPrefab;
        public AudioTracksBase AudioManagerPrefab;

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

            Container.Bind<ITimeService>().To<TimeService>().AsSingle();

            #region Coroutine

            var coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(coroutineRunner);
            Container.Bind<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
            Container.Bind<ICoroutineService>().To<CoroutineService>().AsSingle();
            Container.Bind<IRandomizerService>().To<RandomizerService>().AsSingle();

            #endregion

            Container.Bind<ResultsManager>().FromComponentInNewPrefab(resultsManagerPrefab).AsSingle().NonLazy();




            #region Sound

            // Container.Bind<IAudioExplorer>().To<AudioExplorer>().AsTransient();
             Container.Bind<AudioTracksBase>().FromComponentInNewPrefab(AudioManagerPrefab).AsSingle();

            // var audioTracksDate = Resources.Load<AudioTracksDate>("AudioTracksDate");
            // if (audioTracksDate == null)
            // {
            //     Debug.LogError("AudioTracksDate.asset не найден в папке Resources!");
            // }
            // else
            // {
            //     Container.Bind<AudioTracksDate>().FromInstance(audioTracksDate).AsSingle();
            // }


                #endregion

            

        }
    }
}
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._1._StateMachines.GameStateMachine.States;
using BsseCode._2._Services.GlobalServices.Coroutines;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._3._SupportCode.RandomNumder;
using BsseCode._6._Audio.Data;
using UnityEngine;
using Zenject;
using PauseState = UnityEditor.PauseState;


namespace BsseCode._0._Installers
{
    public class ProjectInstallers : MonoInstaller
    {

        public GameObject resultsManagerPrefab;
        public AudioTracksBase audioManagerPrefab;

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

            Container.Bind<ITimeGlobalService>().To<TimeGlobalService>().AsSingle();
            Container.Bind<IRandomizerService>().To<RandomizerService>().AsSingle();
           
            

            #region Coroutine

            var coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(coroutineRunner);
            Container.Bind<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
            Container.Bind<ICoroutineGlobalService>().To<CoroutineGlobalService>().AsSingle();

            #endregion

            Container.Bind<ResultsManager>().FromComponentInNewPrefab(resultsManagerPrefab).AsSingle().NonLazy();




            #region Sound

            // Container.Bind<IAudioExplorer>().To<AudioExplorer>().AsTransient();
             Container.Bind<AudioTracksBase>().FromComponentInNewPrefab(audioManagerPrefab).AsSingle();

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
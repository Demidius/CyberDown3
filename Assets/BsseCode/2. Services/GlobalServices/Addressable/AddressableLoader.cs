using System.Collections;
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.GlobalServices.Coroutines;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.Addressable
{
    public class AddressableLoader : MonoBehaviour ,IAddressableLoader
    {
       [SerializeField] private AssetReference[] m_levels;

        AsyncOperationHandle<SceneInstance> _sceneInstance;
        int _lastLoadedSceneIndex = -1;
        private CoroutineRunner _runner;
        private GameMachineStarter _starter;

        public AddressableLoader(GameMachineStarter starter)
        {
            _starter = starter;
        }
        
        [Inject]
        void Construct(CoroutineRunner runner)
        {
            _runner = runner;
        }

        void Awake()
        {
            _lastLoadedSceneIndex = -1;
        }

        IEnumerator LoadLevelAsync(AssetReference level)
        {
            _sceneInstance = Addressables.LoadSceneAsync(level, LoadSceneMode.Additive, true);
            yield return _sceneInstance;
        }

        IEnumerator RestartLevelAsync()
        {
            var sceneInstance = Addressables.UnloadSceneAsync(_sceneInstance);

            yield return sceneInstance;
            LoadLevelByIndex(_lastLoadedSceneIndex);
        }

        public void UnloadCurrentLevel()
        {
            if (!_sceneInstance.IsValid())
                return;

            if (_sceneInstance.IsDone)
            {
                Addressables.UnloadSceneAsync(_sceneInstance);
                return;
            }
        }

        public void LoadLevelByIndex(int index)
        {
            UnloadCurrentLevel();
            _runner.StartCoroutine(LoadLevelAsync(m_levels[index]));
            _lastLoadedSceneIndex = index;
        }

        public void RestartCurrentScene()
        {
            if (_lastLoadedSceneIndex == -1)
                return;

            _runner.StartCoroutine(RestartLevelAsync());
        }
    }

    public interface IAddressableLoader
    {
        public void UnloadCurrentLevel();
        public void LoadLevelByIndex(int index);
        public void RestartCurrentScene();
        
    }
}
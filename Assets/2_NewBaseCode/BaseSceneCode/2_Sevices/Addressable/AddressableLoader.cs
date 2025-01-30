using System.Collections;
using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.Coroutines;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.Addressable.NewBaseCode._2._Services.Addressable;
using _2_NewBaseCode.Level1._0._Installers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices.Addressable
{
    public class AddressableLoader : BaseAddressableLoader, IAddressableLoader
    {
        [SerializeField] private AssetReference[] m_levels;

        private AsyncOperationHandle<SceneInstance> _sceneInstance;
        private int _lastLoadedSceneIndex = -1;

        [Inject]
        public  override  void Construct(ICoroutineGlobalService runner)
        {
            base.Construct(runner);
        }
        
        public void UnloadCurrentLevel()
        {
            if (_sceneInstance.IsValid())
            {
                _runner.StartCoroutine(UnloadSceneAsync(_sceneInstance));
            }
        }
        public void LoadLevelByIndex(int index)
        {
            if (index < 0 || index >= m_levels.Length)
            {
                Debug.LogError($"Invalid level index: {index}");
                return;
            }

            _runner.StartCoroutine(LoadLevel(index));
        }

        public void RestartCurrentScene()
        {
            if (_lastLoadedSceneIndex != -1)
            {
                LoadLevelByIndex(_lastLoadedSceneIndex);
            }
        }

        private IEnumerator LoadLevel(int index)
        {
            if (_sceneInstance.IsValid())
            {
                yield return UnloadSceneAsync(_sceneInstance);
            }

            _sceneInstance = Addressables.LoadSceneAsync(m_levels[index], LoadSceneMode.Additive, true);
            _lastLoadedSceneIndex = index;

            yield return _sceneInstance;

            InitializeLevel();
        }

        private void InitializeLevel()
        {
            var levelManager = FindObjectOfType<LevelManager>();
            levelManager?.InitializeScene();
        }
    }
    
    namespace NewBaseCode._2._Services.Addressable
    {
        public interface IAddressableLoader
        {
            void UnloadCurrentLevel();
            void LoadLevelByIndex(int index);
            void RestartCurrentScene();
        }
    }

    
}
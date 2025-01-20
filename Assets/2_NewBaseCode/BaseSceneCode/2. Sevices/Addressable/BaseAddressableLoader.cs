using System.Collections;
using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.Coroutines;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices.Addressable
{
    public abstract class BaseAddressableLoader : MonoBehaviour
    {
        protected ICoroutineGlobalService _runner;

        public virtual void Construct(ICoroutineGlobalService runner)
        {
            _runner = runner;
        }

        protected IEnumerator LoadSceneAsync(AssetReference level, LoadSceneMode mode, bool activateOnLoad)
        {
            var handle = Addressables.LoadSceneAsync(level, mode, activateOnLoad);
            yield return handle;
        }

        protected IEnumerator UnloadSceneAsync(AsyncOperationHandle<SceneInstance> sceneInstance)
        {
            if (sceneInstance.IsValid())
            {
                yield return Addressables.UnloadSceneAsync(sceneInstance);
            }
        }
    }
}
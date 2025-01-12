using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace BsseCode._2._Services.GlobalServices.Addressable
{
    public class AddressableInitHalper : MonoBehaviour
    {
        [SerializeField] AssetReferenceGameObject m_anyPrefabAsset;

        void Start()
        {
            StartCoroutine(Do());
        }

        IEnumerator Do()
        {
            AsyncOperationHandle<GameObject> handle = m_anyPrefabAsset.LoadAssetAsync();

            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                print("AddressableInitHalper Complete");
            }
        }
    }
}
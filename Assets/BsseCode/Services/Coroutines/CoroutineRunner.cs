using UnityEngine;

namespace BsseCode.Services.Coroutines
{
    public class CoroutineRunner : MonoBehaviour
    {
        private void Awake() => 
            DontDestroyOnLoad(gameObject);
    }
}

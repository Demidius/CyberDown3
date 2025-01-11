using UnityEngine;

namespace BaseCode2._2._Services.Coroutines
{
    public class CoroutineRunner : MonoBehaviour
    {
        private void Awake() => 
            DontDestroyOnLoad(gameObject);
    }
}

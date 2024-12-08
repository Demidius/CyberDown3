using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.Coroutines
{
    public class CoroutineRunner : MonoBehaviour
    {
        private void Awake() => 
            DontDestroyOnLoad(gameObject);
    }
}

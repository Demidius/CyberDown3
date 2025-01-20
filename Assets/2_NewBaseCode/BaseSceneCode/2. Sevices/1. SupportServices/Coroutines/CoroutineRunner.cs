using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.Coroutines
{
    public class CoroutineRunner : MonoBehaviour
    {
        
        private void Awake()
        {
            if (transform.parent != null)
            {
                transform.parent = null; 
            }
            
            DontDestroyOnLoad(gameObject);
        }
    }
}

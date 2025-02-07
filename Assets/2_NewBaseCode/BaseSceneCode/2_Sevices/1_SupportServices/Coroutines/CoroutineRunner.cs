using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices.Coroutines
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

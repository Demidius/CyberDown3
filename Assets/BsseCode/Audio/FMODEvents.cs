using UnityEngine;
using FMODUnity;

namespace BsseCode.Audio
{
    public class FMODEvents : MonoBehaviour
    {
        [field: Header("PlayersSteps SFX")]
        [field: SerializeField] public EventReference playersSteps {get; private set;}
        
        
        [field: Header("Shoot SFX")]
        [field: SerializeField] public EventReference shootSound {get; private set;}
        
        [field: Header("Enemy Steps")]
        [field: SerializeField] public EventReference enemyStep {get; private set;}
        
        
        
        
        public static FMODEvents Instance {get; private set;}

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("FMODEvents instance already exists.");
            }
            Instance = this;
        }
        
        
        
    }
}
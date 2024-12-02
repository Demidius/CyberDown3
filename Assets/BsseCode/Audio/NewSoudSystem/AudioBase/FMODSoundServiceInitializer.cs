using UnityEngine;

namespace BsseCode.Audio.NewSoudSystem.AudioBase
{
    public class FMODSoundServiceInitializer : MonoBehaviour
    {
        [SerializeField] private FMODSoundService fmodSoundService;

        private void Start()
        {
            if (fmodSoundService != null)
            {
                fmodSoundService.Initialize();
            }
            else
            {
                Debug.LogError("FMODSoundService не назначен!");
            }
        }
    }
}
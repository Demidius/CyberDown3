using FMODUnity;
using UnityEngine;

namespace BsseCode.Audio.AudioSourcesHandlers
{
   
    public class AudioTracksBase : MonoBehaviour
    {
        
        public EventReference shootTrack;
        public EventReference stepEvent;
        public EventReference Music1;


        private void Start()
        {
            AudioManager.Instance.InitializeSoundPool(shootTrack);
            AudioManager.Instance.InitializeSoundPool(stepEvent);
            AudioManager.Instance.InitializeSoundPool(Music1);
            
        }
    }
    
}
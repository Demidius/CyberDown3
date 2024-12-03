using FMODUnity;
using UnityEngine;

namespace BsseCode.Audio.AudioSourcesHandlers
{
   
    public class AudioTracksBase : MonoBehaviour
    {
        
        public EventReference shootTrack;
        public EventReference stepEvent;
        public EventReference music1;
        public EventReference spiderRun;
        public EventReference explosionSound;


        private void Start()
        {
            AudioManager.Instance.InitializeSoundPool(shootTrack);
            AudioManager.Instance.InitializeSoundPool(stepEvent);
            AudioManager.Instance.InitializeSoundPool(music1);
            AudioManager.Instance.InitializeSoundPool(spiderRun);
            AudioManager.Instance.InitializeSoundPool(explosionSound);
            
        }
    }
    
}
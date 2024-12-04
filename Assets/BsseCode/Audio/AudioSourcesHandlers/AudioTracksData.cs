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
            AudioManager.Instance.InitializeSoundPool(shootTrack, 30);
            AudioManager.Instance.InitializeSoundPool(stepEvent,30);
            AudioManager.Instance.InitializeSoundPool(music1);
            AudioManager.Instance.InitializeSoundPool(spiderRun, 30);
            AudioManager.Instance.InitializeSoundPool(explosionSound, 30);
            
        }
    }
    
}
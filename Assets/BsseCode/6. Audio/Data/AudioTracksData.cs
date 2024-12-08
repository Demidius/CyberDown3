using BsseCode._6._Audio.Managers;
using FMODUnity;
using UnityEngine;

namespace BsseCode._6._Audio.Data
{
    public class AudioTracksBase : MonoBehaviour
    {
        
        public EventReference shootTrack;
        public EventReference stepEvent;
        public EventReference music1;
        public EventReference musicMenu1;
        public EventReference spiderRun;
        public EventReference explosionSound;
        public EventReference emptyBarSound;
        public EventReference refillEnergyBarSound;
        public EventReference energyBarIsFullSound;


        private void Start()
        {
            AudioManager.Instance.InitializeSoundPool(shootTrack, 30);
            AudioManager.Instance.InitializeSoundPool(stepEvent,30);
            AudioManager.Instance.InitializeSoundPool(music1, 1);
            AudioManager.Instance.InitializeSoundPool(musicMenu1, 1);
            AudioManager.Instance.InitializeSoundPool(spiderRun, 30);
            AudioManager.Instance.InitializeSoundPool(explosionSound, 30);
            AudioManager.Instance.InitializeSoundPool(emptyBarSound, 10);
            AudioManager.Instance.InitializeSoundPool(refillEnergyBarSound, 10);
            AudioManager.Instance.InitializeSoundPool(energyBarIsFullSound, 10);
            
        }
    }
    
}
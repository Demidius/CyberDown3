using _2_NewBaseCode.BaseSceneCode._4._Audio.Managers;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._4._Audio.Data
{
    public class AudioTracksBase : MonoBehaviour
    {
        private IAudioManager _audioManager;

        [Inject]
        void Construct(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        // public EventReference shootTrack;
        public EventReference playerSteps;
        // public EventReference music1;
        public EventReference musicMenu;
        // public EventReference spiderRun;
        // public EventReference explosionSound;
        // public EventReference emptyBarSound;
        // public EventReference refillEnergyBarSound;
        // public EventReference energyBarIsFullSound;
        public EventReference click1Sound;
        // public EventReference click2Sound;
        public EventReference click3Sound;
        // public EventReference clickExit;
        // public EventReference levelStartSound;
        // public EventReference beaconSound;
        // public EventReference slowMotionSound;
   

        private void Start()
        {
            // _audioManager.InitializeSoundPool(shootTrack, 30);
            _audioManager.InitializeSoundPool(playerSteps,30);
            // _audioManager.InitializeSoundPool(music1, 3);
            _audioManager.InitializeSoundPool(musicMenu, 3);
            // _audioManager.InitializeSoundPool(spiderRun, 30);
            // _audioManager.InitializeSoundPool(explosionSound, 30);
            // _audioManager.InitializeSoundPool(emptyBarSound, 10);
            // _audioManager.InitializeSoundPool(refillEnergyBarSound, 10);
            // _audioManager.InitializeSoundPool(energyBarIsFullSound, 10);
            _audioManager.InitializeSoundPool(click1Sound, 10);
            // _audioManager.InitializeSoundPool(click2Sound, 10);
            _audioManager.InitializeSoundPool(click3Sound, 10);
            // _audioManager.InitializeSoundPool(clickExit, 10);
            // _audioManager.InitializeSoundPool(levelStartSound, 2);
            // _audioManager.InitializeSoundPool(beaconSound, 2);
            // _audioManager.InitializeSoundPool(slowMotionSound, 2);
            //
            
        }
    }
}
using _2_NewBaseCode.BaseSceneCode._4._Audio.Data;
using _2_NewBaseCode.BaseSceneCode._4._Audio.Managers;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._4._Audio.PlayerAudioHandlers
{
    public class PlayerStepsAudio : MonoBehaviour
    { 
        private AudioTracksBase _audioTracksBase;
        private IAudioManager _audioManager;

        [Inject]
        public void Construct(
            AudioTracksBase audioTracksBase, 
            IAudioManager audioManager
        )
        {
            _audioManager = audioManager;
            _audioTracksBase = audioTracksBase;
        }
        public void PlayStep()
        {
            _audioManager.PlaySound(_audioTracksBase.playerSteps);
        }
    }
}
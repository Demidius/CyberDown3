using NewBaseCode._4._Audio.Data;
using NewBaseCode._4._Audio.Managers;
using UnityEngine;
using Zenject;

namespace NewBaseCode._4._Audio
{
    public class MusicController : MonoBehaviour, IMusicController
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

        public void StartMenuMusic()
        {
            _audioManager.PlaySound(_audioTracksBase.musicMenu, useInstance: true);
        }

        public void StopMenuMusic()
        {
            _audioManager.StopSound(_audioTracksBase.musicMenu);
        }
    }

    public interface IMusicController
    {
        void StartMenuMusic();
        void StopMenuMusic();
    }
}
           // AudioManager.Instance.PlaySound("event:/Music1", useInstance: false, position: _player.transform.position );
            // AudioManager.Instance.InitializeSoundPool("event:/Music1", 1);

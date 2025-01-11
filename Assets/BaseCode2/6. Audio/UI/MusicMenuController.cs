using BaseCode2._6._Audio.Data;
using Zenject;

namespace BaseCode2._6._Audio.UI
{
    public class MusicMenuController
    {
       
        private AudioTracksBase _audioTracksBase;
        private AudioManager _audioManager;

        [Inject]
        public void Construct(
          AudioTracksBase audioTracksBase, AudioManager audioManager
        )
        {
            _audioManager = audioManager;
            _audioTracksBase = audioTracksBase;
        }
        private void StartMenuMusic()
        {
            _audioManager.PlaySound(_audioTracksBase.musicMenu1, useInstance: true);
        }

        private void OnDestroy()
        {
            _audioManager.StopSound(_audioTracksBase.musicMenu1);
        }

        private void OnDisable()
        {
            _audioManager.StopSound(_audioTracksBase.musicMenu1);
        }
    }
}
           // AudioManager.Instance.PlaySound("event:/Music1", useInstance: false, position: _player.transform.position );
            // AudioManager.Instance.InitializeSoundPool("event:/Music1", 1);

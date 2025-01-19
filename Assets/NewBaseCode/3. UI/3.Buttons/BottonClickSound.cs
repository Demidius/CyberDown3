using NewBaseCode._4._Audio.Data;
using NewBaseCode._4._Audio.Managers;

namespace NewBaseCode._3._UI._3.Buttons
{
    public class BottonClickSound
    {
        private readonly IAudioManager _audioManager;
        private readonly AudioTracksBase _audioTracks;

        public BottonClickSound(IAudioManager audioManager, AudioTracksBase audioTracks)
        {
            _audioManager = audioManager;
            _audioTracks = audioTracks;
        }

        public void PlayEnterSound()
        {
            _audioManager.PlaySound(_audioTracks.click1Sound);
        }

        public void PlayExitSound()
        {
            _audioManager.PlaySound(_audioTracks.click3Sound);
        }
    }
}
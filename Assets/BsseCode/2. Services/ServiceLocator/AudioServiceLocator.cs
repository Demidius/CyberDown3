using _2_NewBaseCode.BaseSceneCode._4._Audio.Data;
using _2_NewBaseCode.BaseSceneCode._4._Audio.Managers;
using Zenject;

namespace BsseCode._2._Services.ServiceLocator
{
    public class AudioServiceLocator : IAudioServicesLocator
    {
        public AudioManager AudioManager { get; private set; }
        public AudioTracksBase AudioTracksBase { get; private set; }

        [Inject]
        void Construct(AudioManager audioManager, AudioTracksBase audioTracksBase)
        {
            AudioTracksBase = audioTracksBase;
            AudioManager = audioManager;
        }
        
    }

    public interface IAudioServicesLocator
    {
        public AudioManager AudioManager { get; }
        public AudioTracksBase AudioTracksBase { get; }
    }
}
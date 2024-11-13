namespace BsseCode.Audio.AudioSourcesHandlers
{
    public class MusicPlayer : AudioSources
    {
        private void Start()
        {
            SoundsExplorer.PlaySoundFrom(SoundStorage.backgroundMusic, AudioSource());
        }
    }
}
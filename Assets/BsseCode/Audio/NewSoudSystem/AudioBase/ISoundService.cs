namespace BsseCode.Audio.NewSoudSystem.AudioBase
{
    public interface ISoundService
    {
        SoundDefinition[] Sounds { get; }
        SoundDefinition GetSoundById(int id);
    }
}
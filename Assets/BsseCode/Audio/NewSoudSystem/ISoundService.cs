namespace BsseCode.Audio.NewSoudSystem
{
    public interface ISoundService
    {
        SoundDefinition[] Sounds { get; }
        SoundDefinition GetSoundById (int id);
    }
}
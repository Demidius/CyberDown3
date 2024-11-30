using FMOD.Studio;

namespace BsseCode.Audio.NewSoudSystem
{
    public interface IFMODSoundService : ISoundService
    {
        EventDescription GetFloatParameterDescription(SoundDefinition soundDefinition, FloatParameterDefinition parameter);
        
    }
}
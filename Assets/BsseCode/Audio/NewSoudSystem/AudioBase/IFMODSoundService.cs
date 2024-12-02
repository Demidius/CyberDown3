using FMOD.Studio;

namespace BsseCode.Audio.NewSoudSystem.AudioBase
{
    public interface IFMODSoundService : ISoundService
    {
        EventDescription GetEventDeinition(SoundDefinition soundDefinition);
        PARAMETER_DESCRIPTION GetFloatParameterDescription(SoundDefinition soundDefinition, SoundDefinition.FloatParameterDefinition parameter);
        
    }
}
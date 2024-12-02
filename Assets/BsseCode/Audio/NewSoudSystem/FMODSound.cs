using FMOD.Studio;
using Unity.Entities;

namespace BsseCode.Audio.NewSoudSystem
{
    public struct FMODSound : ICleanupComponentData
    {
        public EventInstance Event;
    }

    public struct FMODFloatParameter : IBufferElementData
    {
        public PARAMETER_ID ParameterId;
        public float CurrentValue;
    }
}
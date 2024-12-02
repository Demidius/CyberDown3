using Unity.Entities;

namespace BsseCode.Audio.NewSoudSystem
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial class FMODUpdateFloatParametersSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref FMODSound fmodSound, in DynamicBuffer<FMODFloatParameter> parameters) =>
            {
                foreach (var parameter in parameters)
                {
                    fmodSound.Event.setParameterByID(parameter.ParameterId, parameter.CurrentValue);
                }
            }).WithoutBurst().Run();
        }
    }
}
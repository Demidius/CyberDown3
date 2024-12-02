using Unity.Entities;

namespace BsseCode.Audio.NewSoudSystem
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class FMODCleanupSoundSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var ecbSystem = World.GetExistingSystemManaged<EndSimulationEntityCommandBufferSystem>();
            var commandBuffer = ecbSystem.CreateCommandBuffer();

            Entities.WithNone<Sound>().ForEach((Entity entity, in FMODSound sound) =>
            {
                sound.Event.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                sound.Event.release();

                commandBuffer.RemoveComponent<FMODSound>(entity);
            }).WithoutBurst().Run();
        }
    }
}
using BsseCode.Audio.NewSoudSystem.AudioBase;
using FMOD;
using FMOD.Studio;
using Unity.Entities;
using UnityEngine.Assertions;
using Zenject;

namespace BsseCode.Audio.NewSoudSystem
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial class FMODSoundSystem : SystemBase
    {
        private IFMODSoundService _soundService;

        [Inject]
        private void Inject(IFMODSoundService soundService)
        {
            _soundService = soundService;
        }

        protected override void OnUpdate()
        {
            var ecbSystem = World.GetExistingSystemManaged<EndInitializationEntityCommandBufferSystem>();
            var commandBuffer = ecbSystem.CreateCommandBuffer();

            Entities.WithNone<FMODSound>().ForEach((Entity entity, in Sound sound) =>
            {
                var soundDefinition = _soundService.GetSoundById(sound.Id);
                var eventDescription = _soundService.GetEventDeinition(soundDefinition);

                var result = eventDescription.createInstance(out var instance);
                Assert.IsTrue(result == RESULT.OK, $"Ошибка создания инстанса звука: {result}");

                result = instance.start();
                Assert.IsTrue(result == RESULT.OK, $"Ошибка запуска звука: {result}");

                commandBuffer.AddComponent(entity, new FMODSound { Event = instance });

                if (SystemAPI.HasComponent<Volume>(entity))
                {
                    var volume = SystemAPI.GetComponent<Volume>(entity);
                    instance.setVolume(volume.Value);
                }

                if (soundDefinition.FloatParameters?.Length > 0)
                {
                    var buffer = commandBuffer.AddBuffer<FMODFloatParameter>(entity);
                    foreach (var parameter in soundDefinition.FloatParameters)
                    {
                        buffer.Add(new FMODFloatParameter
                        {
                            ParameterId = _soundService.GetFloatParameterDescription(soundDefinition, parameter).id,
                            CurrentValue = parameter.DefaultValue
                        });
                    }
                }
            }).WithoutBurst().Run();
        }
    }
}

using BsseCode.Audio.NewSoudSystem.AudioBase;
using Unity.Entities;
using UnityEngine;

namespace BsseCode.Audio.NewSoudSystem
{
    public class SoundAuthoring : MonoBehaviour
    {
        public SoundDefinition soundDefinition;
        public float volume = 1f;
        public GameObject target;
    }

    public class SoundBaker : Baker<SoundAuthoring>
    {
        public override void Bake(SoundAuthoring authoring)
        {
            if (authoring.soundDefinition == null)
            {
                Debug.LogError($"SoundDefinition не задан на объекте {authoring.gameObject.name}");
                return;
            }

            var entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new Sound { Id = authoring.soundDefinition.Id });
            AddComponent(entity, new Volume { Value = authoring.volume });

            if (authoring.soundDefinition.FloatParameters?.Length > 0)
            {
                var buffer = AddBuffer<FloatParameter>(entity);
                foreach (var param in authoring.soundDefinition.FloatParameters)
                {
                    buffer.Add(new FloatParameter { Value = param.DefaultValue });
                }
            }

            if (authoring.target != null)
            {
                var targetEntity = GetEntity(authoring.target, TransformUsageFlags.Dynamic);
                AddComponent(entity, new TrackPosition { Target = targetEntity });
            }
        }
    }

    public struct Sound : IComponentData
    {
        public int Id;
    }

    public struct Volume : IComponentData
    {
        public float Value;
    }

    public struct FloatParameter : IBufferElementData
    {
        public float Value;
    }

    public struct TrackPosition : IComponentData
    {
        public Entity Target;
    }
}
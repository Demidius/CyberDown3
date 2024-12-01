using UnityEngine;
using Unity.Entities;

namespace BsseCode.Audio.NewSoudSystem
{
    public class SoundAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public SoundDefinition SoundDefinition;
        public float Volume = 1;
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponents(entity, new ComponentTypes());
            
        }
        
    }

    public struct Sound : IComponentData
    {
        public int Id;
    }

    public struct Volue : IComponentData
    {
        public float Value;
    }
    
    
}
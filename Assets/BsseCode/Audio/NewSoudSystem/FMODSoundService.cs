using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Zenject;
using Debug = UnityEngine.Debug; 

namespace BsseCode.Audio.NewSoudSystem
{
    [CreateAssetMenu(menuName = "Database/Sounds")]
    public class FMODSoundService : ScriptableObject, ISoundService
    {
        [SerializeField] private SoundDefinition[] sounds;

        public SoundDefinition[] Sounds => sounds;
                
        private SoundData[] soundDatas;
        
        public SoundDefinition GetSoundById(int id)
        {
            foreach (var soundDefinition in sounds)
            {
                if (soundDefinition.Id == id)
                {
                    return soundDefinition;
                }
            }

            throw new ApplicationException($" Sound with id {id} not found");
        }

        public EventDescription GetEventDeinition(SoundDefinition soundDefinition)
        {
            var soundData = soundDatas[soundDefinition.RuntimeIndex];
            if (!soundData.EventDescription.isValid())
                throw new ApplicationException($"Sound with id {soundDefinition.RuntimeIndex} not valid");
            return soundData.EventDescription;
        }

        public PARAMETER_DESCRIPTION GetFloatParameterDescription(
            SoundDefinition soundDefinition, FloatParameterDefinition parameter)
        {
            var soundData = soundDatas[soundDefinition.RuntimeIndex];
            
            var parameterIndex = parameter.RuntimeIndex;
            if (soundData.FloatParameterDescriptions.Length <= parameterIndex)
            {
                throw new ApplicationException($"Sound with id {soundDefinition.RuntimeIndex} not found");
            }
            var parameterDescription = soundData.FloatParameterDescriptions[parameterIndex];
            return parameterDescription;
        }
        
        
        
        public void Initialize()
        {
            soundDatas = new SoundData[sounds.Length];
            for (int index = 0; index < sounds.Length; index++)
            {
                var soundDefinition = sounds[index];
                
                soundDefinition.RuntimeIndex = index;
                
                ref var data = ref soundDatas[index];

                var result = RuntimeManager.StudioSystem.getEvent(soundDefinition.Name, out data.EventDescription);
                if (result != FMOD.RESULT.OK)
                {
                    Debug.LogError($"Sound with id {soundDefinition.Id} not found");
                    continue;
                }
                data.FloatParameterDescriptions = new PARAMETER_DESCRIPTION[soundDefinition.FloaatParameters.Length];
                for (int i = 0; i < soundDefinition.FloaatParameters.Length; i++)
                {
                     ref var parameterDefinition = ref data.FloatParameterDescriptions[i];
                     result = data.EventDescription.getParameterDescriptionByName(
                         soundDefinition.FloaatParameters[i].Name, out parameterDefinition);
                     if (result != FMOD.RESULT.OK)
                     {
                         Debug.LogError($"Event \"{soundDefinition.Name}\" parameter \"{soundDefinition.FloaatParameters[i].Name}\" not found");
                     }

                     soundDefinition.FloaatParameters[i].RuntimeIndex = i;
                }
            }
        }
        
        private struct SoundData
        {
            public EventDescription EventDescription;
            public PARAMETER_DESCRIPTION[] FloatParameterDescriptions;
        }
    }
}
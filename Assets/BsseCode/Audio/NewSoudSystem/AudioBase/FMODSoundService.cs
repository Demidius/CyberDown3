using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace BsseCode.Audio.NewSoudSystem.AudioBase
{
    [CreateAssetMenu(menuName = "Database/Sounds")]
    public class FMODSoundService : ScriptableObject, IFMODSoundService
    {
        [SerializeField] private SoundDefinition[] sounds;

        public SoundDefinition[] Sounds => sounds;

        public SoundDefinition GetSoundById(int id)
        {
            foreach (var sound in sounds)
            {
                if (sound.Id == id)
                    return sound;
            }

            throw new System.Exception($"Sound with id {id} not found");
        }

        public EventDescription GetEventDeinition(SoundDefinition soundDefinition)
        {
            RuntimeManager.StudioSystem.getEvent(soundDefinition.Name, out var eventDescription);
            return eventDescription;
        }

        public PARAMETER_DESCRIPTION GetFloatParameterDescription(SoundDefinition sound, SoundDefinition.FloatParameterDefinition parameter)
        {
            var eventDescription = GetEventDeinition(sound);
            eventDescription.getParameterDescriptionByName(parameter.Name, out var paramDescription);
            return paramDescription;
        }

        // Добавляем метод Initialize
        public void Initialize()
        {
            // Если нужно, здесь можно добавить настройку FMOD или загрузку данных
            Debug.Log("FMODSoundService инициализирован.");
        }
    }
}
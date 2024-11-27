namespace BsseCode.Audio.AudioSourcesHandlers
{
   
    using FMODUnity;
    using UnityEngine;

    public class TestAudio : MonoBehaviour
    {
        [SerializeField]
        [EventRef]
        private string eventPath; // Путь к вашему событию

        private FMOD.Studio.EventInstance soundInstance;

        void Start()
        {
            // Создаём инстанс события
            soundInstance = RuntimeManager.CreateInstance(eventPath);

            // Запускаем воспроизведение
            soundInstance.start();
        }

        void OnDestroy()
        {
            // Останавливаем звук при уничтожении объекта
            soundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            soundInstance.release();
        }
    }
}
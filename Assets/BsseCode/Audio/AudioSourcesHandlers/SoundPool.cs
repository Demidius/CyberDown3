using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;

namespace BsseCode.Audio.AudioSourcesHandlers
{
    public class SoundPool
    {
        private Queue<EventInstance> pool = new Queue<EventInstance>();
        private string soundPath;

        public SoundPool(string soundPath, int initialCount = 5)
        {
            this.soundPath = soundPath;

            for (int i = 0; i < initialCount; i++)
            {
                var instance = RuntimeManager.CreateInstance(soundPath);
                pool.Enqueue(instance);
            }
        }

        public EventInstance GetInstance()
        {
            if (pool.Count > 0)
                return pool.Dequeue();

            return RuntimeManager.CreateInstance(soundPath); // Если пул пуст, создаём новый экземпляр.
        }

        public void ReturnInstance(EventInstance instance)
        {
            instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            pool.Enqueue(instance);
        }
    }
}
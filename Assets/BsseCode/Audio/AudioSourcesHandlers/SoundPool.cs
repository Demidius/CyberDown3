using System.Collections.Generic;
using FMOD;
using FMOD.Studio;
using FMODUnity;

namespace BsseCode.Audio.AudioSourcesHandlers
{
    public class SoundPool
    {
        private Queue<EventInstance> pool = new Queue<EventInstance>();
        private List<EventInstance> activeInstances = new List<EventInstance>();
        private string soundPath;

        public SoundPool(string soundPath, int initialCount = 5)
        {
            if (string.IsNullOrEmpty(soundPath))
            {
                throw new System.ArgumentException("Sound path cannot be null or empty.");
            }

            this.soundPath = soundPath;

            for (int i = 0; i < initialCount; i++)
            {
                var instance = RuntimeManager.CreateInstance(soundPath);
                Set3DAttributes(instance, UnityEngine.Vector3.zero); // Устанавливаем дефолтные 3D атрибуты
                pool.Enqueue(instance);
            }
        }

        public EventInstance GetInstance(UnityEngine.Vector3 position = default)
        {
            EventInstance instance;

            if (pool.Count > 0)
            {
                instance = pool.Dequeue();
            }
            else
            {
                UnityEngine.Debug.LogWarning($"SoundPool for {soundPath} is empty. Creating a new instance.");
                instance = RuntimeManager.CreateInstance(soundPath);
            }

            Set3DAttributes(instance, position); // Устанавливаем 3D атрибуты при выдаче
            activeInstances.Add(instance); // Добавляем в список активных
            return instance;
        }

        public void ReturnInstance(EventInstance instance)
        {
            if (instance.isValid())
            {
                instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                Set3DAttributes(instance, UnityEngine.Vector3.zero); // Сбрасываем 3D атрибуты
                activeInstances.Remove(instance); // Убираем из списка активных
                pool.Enqueue(instance); // Возвращаем в пул
            }
            else
            {
                UnityEngine.Debug.LogWarning("Attempted to return an invalid EventInstance to the pool.");
            }
        }

        public void StopAll()
        {
            // Останавливаем все активные экземпляры
            foreach (var instance in activeInstances)
            {
                if (instance.isValid())
                {
                    instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                }
            }

            // Возвращаем все активные экземпляры в пул
            while (activeInstances.Count > 0)
            {
                var instance = activeInstances[0];
                ReturnInstance(instance);
            }
        }

        public void ClearPool()
        {
            // Очищаем активные звуки
            StopAll();

            // Очищаем пул
            while (pool.Count > 0)
            {
                var instance = pool.Dequeue();
                if (instance.isValid())
                {
                    instance.release();
                }
            }
        }

        private void Set3DAttributes(EventInstance instance, UnityEngine.Vector3 position)
        {
            if (instance.isValid())
            {
                var attributes = RuntimeUtils.To3DAttributes(position);
                instance.set3DAttributes(attributes);
            }
        }
    }
}

using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;

namespace _2_NewBaseCode.BaseSceneCode._4._Audio.Data
{
    public class SoundPool
    {
        private Queue<EventInstance> _pool = new Queue<EventInstance>();
        private List<EventInstance> _activeInstances = new List<EventInstance>();
        private string _soundPath;

        public SoundPool(string soundPath, int initialCount = 5)
        {
            if (string.IsNullOrEmpty(soundPath))
            {
                throw new System.ArgumentException("Sound path cannot be null or empty.");
            }

            this._soundPath = soundPath;

            for (int i = 0; i < initialCount; i++)
            {
                var instance = RuntimeManager.CreateInstance(soundPath);
                Set3DAttributes(instance, UnityEngine.Vector3.zero); // Устанавливаем дефолтные 3D атрибуты
                _pool.Enqueue(instance);
            }
        }

        public EventInstance GetInstance(UnityEngine.Vector3 position = default)
        {
            EventInstance instance;

            if (_pool.Count > 0)
            {
                instance = _pool.Dequeue();
            }
            else
            {
                instance = RuntimeManager.CreateInstance(_soundPath);
            }

            Set3DAttributes(instance, position); // Устанавливаем 3D атрибуты при выдаче
            _activeInstances.Add(instance); // Добавляем в список активных
            return instance;
        }

        public void ReturnInstance(EventInstance instance)
        {
            if (instance.isValid())
            {
                instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                Set3DAttributes(instance, UnityEngine.Vector3.zero); // Сбрасываем 3D атрибуты
                _activeInstances.Remove(instance); // Убираем из списка активных
                _pool.Enqueue(instance); // Возвращаем в пул
            }
            else
            {
                UnityEngine.Debug.Log("Attempted to return an invalid EventInstance to the pool.");
            }
        }

        public void StopAll()
        {
            // Останавливаем все активные экземпляры
            foreach (var instance in _activeInstances)
            {
                if (instance.isValid())
                {
                    instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                }
            }

            // Возвращаем все активные экземпляры в пул
            while (_activeInstances.Count > 0)
            {
                var instance = _activeInstances[0];
                ReturnInstance(instance);
            }
        }

        public void ClearPool()
        {
            // Очищаем активные звуки
            StopAll();

            // Очищаем пул
            while (_pool.Count > 0)
            {
                var instance = _pool.Dequeue();
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

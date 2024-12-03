using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace BsseCode.Audio.AudioSourcesHandlers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        private Dictionary<string, SoundPool> soundPools = new Dictionary<string, SoundPool>();

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        // Инициализация пула для звука
        public SoundPool InitializeSoundPool(EventReference soundPath, int initialCount = 5)
        {
            if (string.IsNullOrEmpty(soundPath.Path))
            {
                Debug.LogWarning("Sound path is empty!");
                return null;
            }

            if (!soundPools.ContainsKey(soundPath.Path))
            {
                soundPools[soundPath.Path] = new SoundPool(soundPath.Path, initialCount);
            }

            return soundPools[soundPath.Path];
        }

        // Воспроизведение звука
        public void PlaySound(EventReference soundPath, bool useInstance = false, Vector3? position = null)
        {
            if (string.IsNullOrEmpty(soundPath.Path))
            {
                Debug.LogWarning("Sound path is empty!");
                return;
            }

            if (!useInstance)
            {
                // Воспроизведение одиночного звука
                if (position.HasValue)
                    RuntimeManager.PlayOneShot(soundPath, position.Value);
                else
                    RuntimeManager.PlayOneShot(soundPath);
            }
            else
            {
                // Использование звукового пула
                if (!soundPools.ContainsKey(soundPath.Path))
                {
                    Debug.LogWarning($"Sound pool for {soundPath.Path} not found. Initializing new pool.");
                    InitializeSoundPool(soundPath);
                }

                var instance = soundPools[soundPath.Path].GetInstance();

                // Устанавливаем 3D-атрибуты
                if (position.HasValue)
                    instance.set3DAttributes(RuntimeUtils.To3DAttributes(position.Value));
                else
                    instance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));

                instance.start();

                // Возвращаем в пул после завершения
                StartCoroutine(ReturnToPoolAfterPlay(instance, soundPath.Path));
            }
        }

        // Остановка звука по пути
        public void StopSound(EventReference soundPath)
        {
            if (string.IsNullOrEmpty(soundPath.Path))
            {
                Debug.LogWarning("Sound path is empty!");
                return;
            }

            if (soundPools.ContainsKey(soundPath.Path))
            {
                soundPools[soundPath.Path].StopAll();
            }
            else
            {
                Debug.LogWarning($"Sound pool for {soundPath.Path} not found.");
            }
        }

        // Остановка всех звуков
        public void StopAllSounds()
        {
            foreach (var pool in soundPools.Values)
            {
                pool.StopAll();
            }
        }

        // Возвращение экземпляра в пул после завершения воспроизведения
        private System.Collections.IEnumerator ReturnToPoolAfterPlay(EventInstance instance, string soundPath)
        {
            if (!instance.isValid())
            {
                Debug.LogWarning("Event instance is not valid!");
                yield break;
            }

            instance.getDescription(out var eventDescription);

            if (eventDescription.isValid())
            {
                eventDescription.getLength(out int length);
                yield return new WaitForSeconds(length / 1000f);
            }

            if (soundPools.ContainsKey(soundPath))
            {
                soundPools[soundPath].ReturnInstance(instance);
            }

            instance.release(); // Освобождаем ресурс
        }
    }
}

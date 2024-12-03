using System;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace BsseCode.Audio.AudioSourcesHandlers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        private Dictionary<string, SoundPool> soundPools = new Dictionary<string, SoundPool>();

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        // Инициализация пула для звука
        public void InitializeSoundPool(string soundPath, int initialCount = 5)
        {
            if (!soundPools.ContainsKey(soundPath))
            {
               soundPools[soundPath] = new SoundPool(soundPath, initialCount);
            }
            
        }
 public SoundPool InitializeSoundPool(EventReference soundPath, int initialCount = 5)
        {
            if (!soundPools.ContainsKey(soundPath.Path))
            {
               return soundPools[soundPath.Path] = new SoundPool(soundPath.Path, initialCount);
            }
            return soundPools[soundPath.Path];
        }

        // Воспроизведение звука
        public void PlaySound(string soundPath, bool useInstance = false, float volume = 1f, Vector3? position = null)
        {
            if (!useInstance)
            {
                // Одиночное воспроизведение
                if (position.HasValue)
                    RuntimeManager.PlayOneShot(soundPath, position.Value);
                else
                    RuntimeManager.PlayOneShot(soundPath);
            }
            else
            {
                // Воспроизведение через экземпляр
                if (!soundPools.ContainsKey(soundPath))
                    InitializeSoundPool(soundPath);

                var instance = soundPools[soundPath].GetInstance();

                // Устанавливаем громкость и другие параметры
                instance.setVolume(volume);

                // Если указана позиция, прикрепляем к объекту
                if (position.HasValue)
                    RuntimeManager.AttachInstanceToGameObject(instance, transform, GetComponent<Rigidbody>());

                // Воспроизводим звук
                instance.start();

                // Возвращаем в пул после завершения
                StartCoroutine(ReturnToPoolAfterPlay(instance, soundPath));
            }
        }
        
 public void PlaySound(EventReference soundPath, bool useInstance = false, float volume = 1f, Vector3? position = null)
        {
            if (!useInstance)
            {
                // Одиночное воспроизведение
                if (position.HasValue)
                    RuntimeManager.PlayOneShot(soundPath, position.Value);
                else
                    RuntimeManager.PlayOneShot(soundPath);
            }
            else
            {
                // Воспроизведение через экземпляр
                if (!soundPools.ContainsKey(soundPath.Path))
                    InitializeSoundPool(soundPath.Path);

                var instance = soundPools[soundPath.Path].GetInstance();

                // Устанавливаем громкость и другие параметры
                instance.setVolume(volume);

                // Если указана позиция, прикрепляем к объекту
                if (position.HasValue)
                    RuntimeManager.AttachInstanceToGameObject(instance, transform, GetComponent<Rigidbody>());

                // Воспроизводим звук
                instance.start();

                // Возвращаем в пул после завершения
                StartCoroutine(ReturnToPoolAfterPlay(instance, soundPath.Path));
            }
        }

        private System.Collections.IEnumerator ReturnToPoolAfterPlay(EventInstance instance, string soundPath)
        {
            EventDescription eventDescription;
            instance.getDescription(out eventDescription);

            int length = 0;
            eventDescription.getLength(out length);

            yield return new WaitForSeconds(length / 1000f);

            if (soundPools.ContainsKey(soundPath))
            {
                soundPools[soundPath].ReturnInstance(instance);
            }
        }
    }
}

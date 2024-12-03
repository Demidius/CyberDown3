using System;
using BsseCode.Audio.AudioSourcesHandlers;
using BsseCode.Caracters.Hero;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.EnemesPool
{
    public class EnemyAudioController : MonoBehaviour
    {
        private AudioTracksBase _audioTracksBase;

        [Inject]
        public void Construct(
            Player player, AudioTracksBase audioTracksBase
        )
        {
            _audioTracksBase = audioTracksBase;
        }

        private void Start()
        {
            PlayBlades();
        }
        public void PlayBlades()
        {
            AudioManager.Instance.PlaySound(_audioTracksBase.spiderRun, useInstance: true, position: this.transform.position);
        }

        // public EventReference bladesEvent;
        //
        // public EventReference explosionSoundEvent;
        //
        // private FMOD.Studio.EventInstance bladesInstance;
        // private bool isBladesPlaying = false;
        //
        // private void Update()
        // {
        //     if (isBladesPlaying && bladesInstance.isValid())
        //     {
        //         // Обновляем позицию звука
        //         // bladesInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        //     }
        // }
        //
        // public void PlayBlades()
        // {
        //     
        //     
        //     
        //     
        //     // Создаем экземпляр звука
        //     // bladesInstance = RuntimeManager.CreateInstance(bladesEvent);
        //     //
        //     // // Устанавливаем начальные 3D-атрибуты
        //     // bladesInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        //     //
        //     // // Запускаем звук
        //     // bladesInstance.start();
        //     //
        //     // // Включаем флаг для обновления позиции
        //     // isBladesPlaying = true;
        // }
        //
        // public void DieRuner()
        // {
        //     if (bladesInstance.isValid())
        //     {
        //         BledesStop();
        //
        //         // Дополнительный звук взрыва
        //         ExplosionSound();
        //     }
        // }
        //
        private void BledesStop()
        {
            // // Останавливаем звук
            // bladesInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            //
            // // Освобождаем ресурсы
            // bladesInstance.release();
            //
            // // Выключаем флаг обновления
            // isBladesPlaying = false;
        }
        //
        // private void OnDestroy()
        // {
        //     DieRuner();
        // }
        //
        public void ExplosionSound()
        {
            AudioManager.Instance.PlaySound(_audioTracksBase.explosionSound, useInstance: false, position: this.transform.position);
        }
    }
}
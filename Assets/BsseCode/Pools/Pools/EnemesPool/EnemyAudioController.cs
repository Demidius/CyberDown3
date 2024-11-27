using System;
using FMODUnity;
using UnityEngine;

namespace BsseCode.Pools.Pools.EnemesPool
{
    public class EnemyAudioController : MonoBehaviour
    {
        [EventRef] public EventReference bladesEvent;

        [EventRef] public EventReference explosionSoundEvent;

        private FMOD.Studio.EventInstance bladesInstance;
        private bool isBladesPlaying = false;

        private void Update()
        {
            if (isBladesPlaying && bladesInstance.isValid())
            {
                // Обновляем позицию звука
                bladesInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
            }
        }
        public void PlayBlades()
        {
            // Создаем экземпляр звука
            bladesInstance = RuntimeManager.CreateInstance(bladesEvent);
        
            // Устанавливаем начальные 3D-атрибуты
            bladesInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        
            // Запускаем звук
            bladesInstance.start();
        
            // Включаем флаг для обновления позиции
            isBladesPlaying = true;
        }
        
        public void DieRuner()
        {
            if (bladesInstance.isValid())
            {
                BledesStop();
        
                // Дополнительный звук взрыва
                ExplosionSound();
            }
        }
        
        private void BledesStop()
        {
            // Останавливаем звук
            bladesInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        
            // Освобождаем ресурсы
            bladesInstance.release();
        
            // Выключаем флаг обновления
            isBladesPlaying = false;
        }

        private void OnDestroy()
        {
            DieRuner();
        }

        public void ExplosionSound()
        {
            RuntimeManager.PlayOneShot(explosionSoundEvent, transform.position);
        }
    }
}
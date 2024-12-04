using System;
using BsseCode.Audio.AudioSourcesHandlers;
using BsseCode.Caracters.Hero;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.EnemesPool
{
    public class EnemyAudioController : MonoBehaviour
    {
        private AudioTracksBase _audioTracksBase;
        private EventInstance _spiderRunInstance;

        [Inject]
        public void Construct(Player player, AudioTracksBase audioTracksBase)
        {
            _audioTracksBase = audioTracksBase;
        }

        private void OnEnable()
        {
            PlayRunning();
        }

        private void OnDisable()
        {
            StopRunning();
        }

        public void PlayRunning()
        {
            if (_audioTracksBase != null && AudioManager.Instance != null)
            {
                _spiderRunInstance = AudioManager.Instance.PlaySoundWithInstance(
                    _audioTracksBase.spiderRun,
                    useInstance: true,
                    position: this.transform.position
                );
            }
            else
            {
                Debug.LogWarning("Spider run audio track or AudioManager is not set.");
            }
        }

        private void Update()
        {
            if (_spiderRunInstance.isValid())
            {
                _spiderRunInstance.set3DAttributes(RuntimeUtils.To3DAttributes(this.transform.position));
            }
        }

        private void StopRunning()
        {
            if (_spiderRunInstance.isValid())
            {
                _spiderRunInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                _spiderRunInstance.release();
            }
        }

        public void ExplosionSound()
        {
            if (_audioTracksBase != null && AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySound(
                    _audioTracksBase.explosionSound,
                    useInstance: false,
                    position: this.transform.position
                );
            }
            else
            {
                Debug.LogWarning("Explosion sound or AudioManager is not set.");
            }
        }
    }
}

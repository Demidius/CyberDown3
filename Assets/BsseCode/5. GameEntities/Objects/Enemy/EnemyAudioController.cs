using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._5._GameEntities.Hero;
using BsseCode._6._Audio.Data;
using BsseCode._6._Audio.Managers;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.Enemy
{
    public class EnemyAudioController : MonoBehaviour
    {
        private AudioTracksBase _audioTracksBase;
        private EventInstance _spiderRunInstance;
        private GameMachineStarter _gameMachineStarter;

        [Inject]
        public void Construct(AudioTracksBase audioTracksBase, GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
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
            if (_audioTracksBase != null && _gameMachineStarter.audioManager != null)
            {
                _spiderRunInstance = _gameMachineStarter.audioManager.PlaySoundWithInstance(
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
            if (_audioTracksBase != null && _gameMachineStarter.audioManager != null)
            {
                _gameMachineStarter.audioManager.PlaySound(
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

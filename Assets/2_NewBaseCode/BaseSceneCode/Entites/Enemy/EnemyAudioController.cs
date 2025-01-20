using _2_NewBaseCode.BaseSceneCode._4._Audio.Data;
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.ServiceLocator;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode.Entites.Enemy
{
    public class EnemyAudioController : MonoBehaviour
    {
        private AudioTracksBase _audioTracksBase;
        private EventInstance _spiderRunInstance;
        private IGameMachineModule _gameMachineModule;
        private IAudioServicesLocator _audioServicesLocator;

        [Inject]
        public void Construct(
            IAudioServicesLocator audioServicesLocator, 
            IGameMachineModule gameMachineModule
            )
        {
            _audioServicesLocator = audioServicesLocator;
            _gameMachineModule = gameMachineModule;
        }

        private void OnEnable()
        {
            // PlayRunning();
        }

        private void OnDisable()
        {
            StopRunning();
        }

        // public void PlayRunning()
        // {
        //     if (_audioTracksBase != null && _audioServicesLocator.AudioManager != null)
        //     {
        //     //     _spiderRunInstance = _audioServicesLocator.AudioManager.PlaySoundWithInstance(
        //     //         // // _audioTracksBase.spiderRun,
        //     //         // useInstance: true,
        //     //         // position: this.transform.position
        //     //     // );
        //     // }
        //     else
        //     {
        //         Debug.LogWarning("Spider run audio track or AudioManager is not set.");
        //     }
        // }

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
            // if (_audioTracksBase != null && _audioServicesLocator.AudioManager != null)
            // {
            //     _audioServicesLocator.AudioManager.PlaySound(
            //         _audioTracksBase.explosionSound,
            //         useInstance: false,
            //         position: this.transform.position
            //     );
            // }
            // else
            // {
            //     Debug.LogWarning("Explosion sound or AudioManager is not set.");
            // }
        }
    }
}

using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.ServiceLocator;
using FMOD.Studio;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.Beacon
{
    public class Locator : MonoBehaviour
    {
        private GameMachineStarter _starter;
        private EventInstance _beaconSoundInstance;
        private IAudioServicesLocator _audioServicesLocator;

        [Inject]
        void Construct(
            GameMachineStarter starter,
            IAudioServicesLocator audioServicesLocator)
        {
            _audioServicesLocator = audioServicesLocator;
            _starter = starter;
        }

        void Start()
        {
            _beaconSoundInstance = _audioServicesLocator.AudioManager.PlaySoundWithInstance(_audioServicesLocator.AudioTracksBase.beaconSound,
                useInstance: true,
                position: this.transform.position
            );
        }

        private void OnDestroy()
        {
            _beaconSoundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            _beaconSoundInstance.release();
        }
    }
}
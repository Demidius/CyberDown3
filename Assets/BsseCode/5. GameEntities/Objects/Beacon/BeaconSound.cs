using BsseCode._1._StateMachines.GameStateMachine;
using FMOD.Studio;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.BeaconSound
{
    public class Locator : MonoBehaviour
    {
        private GameMachineStarter _starter;
        private EventInstance _beaconSoundInstance;
        
        [Inject]
        void Construct(GameMachineStarter starter)
        {
            _starter = starter;
        }

        void Start()
        {
            _beaconSoundInstance = _starter.audioManager.PlaySoundWithInstance(_starter.audioTracksBase.beaconSound,
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
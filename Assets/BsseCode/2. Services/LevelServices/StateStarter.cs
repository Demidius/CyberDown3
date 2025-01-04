using BsseCode._1._StateMachines.GameStateMachine;
using FMOD.Studio;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.LevelServices
{
    public class StateStarter : MonoBehaviour
    {
        private GameMachineStarter _starter;
        private EventInstance _slowMotionSoundInstance;
        [Inject]
        void Construct(GameMachineStarter starter)
        {
            _starter = starter;
        }

        void Start()
        {
            _starter.GameStateMachine.SetState(_starter.GameplayState);
            
            _slowMotionSoundInstance = _starter.audioManager.PlaySoundWithInstance(_starter.audioTracksBase.slowMotionSound,
                useInstance: true,
                position: this.transform.position
            );
            
            _starter.GameStateMachine.SetState(_starter.WindowState);
            
        }

        private void OnDestroy()
        {
            _slowMotionSoundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            _slowMotionSoundInstance.release();
        }
    }
}
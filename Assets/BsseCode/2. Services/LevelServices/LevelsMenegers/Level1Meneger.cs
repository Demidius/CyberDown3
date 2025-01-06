using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._5._GameEntities.Objects.Beacon;
using FMOD.Studio;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.LevelServices.LevelsMenegers
{
    public class Level1Meneger : MonoBehaviour
    {
        private GameMachineStarter _starter;
        private EventInstance _slowMotionSoundInstance;
        private EventInstance _levelMusicInstance;

        [SerializeField] private BaseController beacon1;
        [SerializeField] private BaseController beacon2;
        [SerializeField] private BaseController beacon3;
        [SerializeField] private BaseController beacon4;
        
        
        [Inject]
        void Construct(GameMachineStarter starter)
        {
            _starter = starter;
        }

        void Start()
        {
            _starter.GameStateMachine.SetState(_starter.GameplayState);
            
            StartSlowmotionSound();
            StartLevelMusic();
            
            _starter.GameStateMachine.SetState(_starter.WindowState);
            
        }

        private void StartSlowmotionSound()
        {
            _slowMotionSoundInstance = _starter.audioManager.PlaySoundWithInstance(_starter.audioTracksBase.slowMotionSound,
                useInstance: true,
                position: this.transform.position
            );
        }

        private void StartLevelMusic()
        {
            _levelMusicInstance = _starter.audioManager.PlaySoundWithInstance(_starter.audioTracksBase.music1,
                useInstance: true,
                position: this.transform.position
            );
        }

        void Update()
        {
            if (beacon1.IsFull && beacon2.IsFull && beacon3.IsFull && beacon4.IsFull)
            {
                Debug.Log("Finish");
                _starter.GameStateMachine.SetState(_starter.FinishState);
            }
        }
        

        private void OnDestroy()
        {
            _slowMotionSoundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            _levelMusicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            _slowMotionSoundInstance.release();
        }
    }
}
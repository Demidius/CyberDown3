using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.ServiceLocator;
using BsseCode._5._GameEntities.Objects.Beacon;
using FMOD.Studio;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.LevelServices.LevelsMenegers
{
    public class Level1Maneger : MonoBehaviour
    {
        private IGameMachineModule _module;
        private EventInstance _slowMotionSoundInstance;
        private EventInstance _levelMusicInstance;

        [SerializeField] private BaseController beacon1;
        [SerializeField] private BaseController beacon2;
        [SerializeField] private BaseController beacon3;
        [SerializeField] private BaseController beacon4;
        private IAudioServicesLocator _audioServicesLocator;


        [Inject]
        void Construct(
            IGameMachineModule module,
            IAudioServicesLocator audioServicesLocator)
        {
            _audioServicesLocator = audioServicesLocator;
            _module = module;
        }

        void Start()
        {
            _module.GameMachine.SetState(_module.GameplayState);
            
            StartSlowmotionSound();
            StartLevelMusic();
            
            _module.GameMachine.SetState(_module.WindowState);
            
        }

        private void StartSlowmotionSound()
        {
            // _slowMotionSoundInstance = _audioServicesLocator.AudioManager.PlaySoundWithInstance(_audioServicesLocator.AudioTracksBase.slowMotionSound,
            //     useInstance: true,
            //     position: this.transform.position
            // );
        }

        private void StartLevelMusic()
        {
            // _levelMusicInstance = _audioServicesLocator.AudioManager.PlaySoundWithInstance(_audioServicesLocator.AudioTracksBase.music1,
            //     useInstance: true,
            //     position: this.transform.position
            // );
        }

        void Update()
        {
            if (beacon1.IsFull && beacon2.IsFull && beacon3.IsFull && beacon4.IsFull)
            {
                Debug.Log("Finish");
                _module.GameMachine.SetState(_module.FinishState);
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
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.GlobalServices.PlayerHandlerFl;
using BsseCode._2._Services.ServiceLocator;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode.Entites.Hero
{
    public class HeroAudioController : MonoBehaviour
    {
        private PlayerHandler _playerHandler;
        private IGameMachineModule _gameMachineModule;
        private IAudioServicesLocator _audioServicesLocator;

        [Inject]
        public void Construct(
            PlayerHandler playerHandler,
            IGameMachineModule gameMachineModule,
            IAudioServicesLocator audioServicesLocator
            )
        {
            _audioServicesLocator = audioServicesLocator;
            _gameMachineModule = gameMachineModule;
            _playerHandler = playerHandler;
            
        }

        // public void PlayStep()
        // {
        //     _audioServicesLocator.AudioManager.PlaySound(_audioServicesLocator.AudioTracksBase.stepEvent, useInstance: false, position: _playerHandler.CurrentPlayer.transform.position);
        // }
    }
}
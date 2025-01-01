using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.GlobalServices.PlayerHandlerFl;
using BsseCode._6._Audio.Data;
using BsseCode._6._Audio.Managers;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Hero
{
    public class HeroAudioController : MonoBehaviour
    {
     
        private AudioTracksBase _audioTracksBase;
        private PlayerHandler _playerHandler;
        private GameMachineStarter _gameMachineStarter;

        [Inject]
        public void Construct(PlayerHandler playerHandler ,AudioTracksBase audioTracksBase, GameMachineStarter gameMachineStarter )
        {
            _gameMachineStarter = gameMachineStarter;
            _playerHandler = playerHandler;
            _audioTracksBase = audioTracksBase;
        }

        public void PlayStep()
        {
            _gameMachineStarter.audioManager.PlaySound(_audioTracksBase.stepEvent, useInstance: false, position: _playerHandler.CurrentPlayer.transform.position);
        }
    }
}
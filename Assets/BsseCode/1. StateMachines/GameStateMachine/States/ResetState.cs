using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices;
using UnityEngine;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class ResetState : IGameState
    {
        
        private GameMachineStarter _gameMachineStarter;

        private float _temtTimeSpeed;

        public ResetState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            _gameMachineStarter.playerHandler.DestroyPlayer();
            _gameMachineStarter.uiController.ResetStatePanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void ReturnToGame()
        {
            _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.GameplayState);
        }

        public void Exit()
        {
            Time.timeScale = 1;
            _gameMachineStarter.playerHandler.CreatePlayer();
            _gameMachineStarter.uiController.ResetStatePanel.SetActive(false);
        }
    }
}
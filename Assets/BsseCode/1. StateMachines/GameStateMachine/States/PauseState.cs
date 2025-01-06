using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices;
using UnityEngine;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class PauseState : IGameState
    {
        
        private GameMachineStarter _gameMachineStarter;

        private float _temtTimeSpeed;

        public PauseState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            _gameMachineStarter.PCInputGlobalService.PauseEvent += ReturnToGame;
            _gameMachineStarter.uiController.PausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void ReturnToGame(bool OnOff)
        {
            if (!OnOff)
            {
                _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.GameplayState);
            }
        }

        public void ReturnToMenu()
        {
            _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.MainMenuState);
        }

        public void Exit()
        {
            Time.timeScale = 1; 
            _gameMachineStarter.uiController.PausePanel.SetActive(false);
            _gameMachineStarter.PCInputGlobalService.PauseEvent -= ReturnToGame;
        }
    }
}
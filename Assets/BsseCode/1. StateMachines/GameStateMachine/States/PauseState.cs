using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices;
using UnityEngine;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class PauseState : IGameState
    {
        public IGameState CurrentState;
        private GameMachineStarter _gameMachineStarter;

        private float _temtTimeSpeed;

        public PauseState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            _gameMachineStarter.PCInputGlobalService.PauseEvent += ReturnToGame;
            Debug.Log("Enter PauseState");
            _gameMachineStarter.uiController.PausePanel.SetActive(true);
            // _temtTimeSpeed = _gameMachineStarter.TimeGlobalService.TimeScale;
            // _gameMachineStarter.TimeGlobalService.TimeScale = 0;
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
            Time.timeScale = 1; // Возвращение времени к нормальному состоянию
            _gameMachineStarter.uiController.PausePanel.SetActive(false);
            // _gameMachineStarter.TimeGlobalService.TimeScale = _temtTimeSpeed;
            // _temtTimeSpeed = 1;
            Time.timeScale = 1;
            _gameMachineStarter.PCInputGlobalService.PauseEvent -= ReturnToGame;
        }
    }
}
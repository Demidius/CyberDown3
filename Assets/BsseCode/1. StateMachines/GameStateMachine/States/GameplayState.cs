using System;
using BsseCode._3._SupportCode.Constants;
using Unity.VisualScripting;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class GameplayState : IGameState
    {
        private GameMachineStarter _gameMachineStarter;
        public event Action OnGameState;

        public GameplayState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            _gameMachineStarter.PCInputGlobalService.PauseEvent += StartPause;
            Debug.Log("Gameplay: Enter");
            OnGameState?.Invoke();
            _gameMachineStarter.uiController.HUD.GameObject().SetActive(true);
            _gameMachineStarter.uiController.CursorToSprite.GameObject().SetActive(true);
            
            
            _gameMachineStarter.playerHandler.CreatePlayer();

            _gameMachineStarter.PCInputGlobalService.OnGameplayState = true;
        }

        public void Exit()
        {
            _gameMachineStarter.uiController.HUD.GameObject().SetActive(false);
            _gameMachineStarter.uiController.CursorToSprite.GameObject().SetActive(false);
            _gameMachineStarter.PCInputGlobalService.OnGameplayState = false;
            _gameMachineStarter.PCInputGlobalService.PauseEvent -= StartPause;
        }

        public void StartMenu()
        {
            // Переход к загрузке уровня
            _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.MainMenuState);
        }

        public void StartPause(bool OnOff)
        {
            if (OnOff)
            {
                _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.PauseState);
            }
        }
    }
}
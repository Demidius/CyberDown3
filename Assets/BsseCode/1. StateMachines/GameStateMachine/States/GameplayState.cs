using System;
using BsseCode._3._SupportCode.Constants;
using Unity.VisualScripting;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class GameplayState : IGameState
    {
        private readonly GameMachineStarter _gameMachineStarter;
        public event Action OnGameState;

        public GameplayState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter ?? throw new ArgumentNullException(nameof(gameMachineStarter));
        }

        public void Enter()
        {
            Debug.Log("Gameplay: Enter");

            SubscribeToEvents();
            InitializeGameplayUI();
            CreatePlayer();

            _gameMachineStarter.PCInputGlobalService.OnGameplayState = true;
            OnGameState?.Invoke();
        }

        public void Exit()
        {
            DeinitializeGameplayUI();
            UnsubscribeFromEvents();

            _gameMachineStarter.PCInputGlobalService.OnGameplayState = false;
        }

        public void StartMenu()
        {
            _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.MainMenuState);
        }

        public void StartPause(bool isPaused)
        {
            if (isPaused)
            {
                _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.PauseState);
            }
        }

        private void SubscribeToEvents()
        {
            _gameMachineStarter.PCInputGlobalService.PauseEvent += StartPause;
        }

        private void UnsubscribeFromEvents()
        {
            _gameMachineStarter.PCInputGlobalService.PauseEvent -= StartPause;
        }

        private void InitializeGameplayUI()
        {
            SetActiveState(_gameMachineStarter.uiController.HUD.GameObject(), true);
            SetActiveState(_gameMachineStarter.uiController.CursorToSprite.GameObject(), true);
        }

        private void DeinitializeGameplayUI()
        {
            SetActiveState(_gameMachineStarter.uiController.HUD.GameObject(), false);
            SetActiveState(_gameMachineStarter.uiController.CursorToSprite.GameObject(), false);
        }

        private void CreatePlayer()
        {
            _gameMachineStarter.playerHandler?.CreatePlayer();
        }

        private void SetActiveState(GameObject obj, bool state)
        {
            if (obj != null)
            {
                obj.SetActive(state);
            }
        }
    }
}

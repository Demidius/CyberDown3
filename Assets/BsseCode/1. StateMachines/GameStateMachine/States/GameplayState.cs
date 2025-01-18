using System;
using BsseCode._2._Services.ServiceLocator;
using BsseCode._3._SupportCode.Constants;
using NewBaseCode._1._GameMachine;
using Unity.VisualScripting;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class GameplayState : IGameState
    {
        private readonly IGameMachineModule _gameMachineModule;
        private IUIServiceLocator _uiServiceLocator;
        private IManagersServiceLocator _managersServiceLocator;
        private IReusableServiceLocator _reusableServiceLocator;

        public bool SlowMotionTimeIsActive { get; private set;  }

        public GameplayState(
            IGameMachineModule gameMachineModule, 
            IUIServiceLocator uiServiceLocator,
            IManagersServiceLocator managersServiceLocator,
            IReusableServiceLocator reusableServiceLocator)
        {
            _reusableServiceLocator = reusableServiceLocator;
            _managersServiceLocator = managersServiceLocator;
            _uiServiceLocator = uiServiceLocator;
            _gameMachineModule = gameMachineModule ?? throw new ArgumentNullException(nameof(gameMachineModule));
        }

        public void Enter()
        {
            Debug.Log("Gameplay: Enter");

            SubscribeToEvents();
            InitializeGameplayUI();
            CreatePlayer();
            SlowmotionParams();

            _reusableServiceLocator.PCInputGlobalService.OnGameplayState = true;
        }


        private void SlowmotionParams()
        {
            if (SlowMotionTimeIsActive)
            {
                _reusableServiceLocator.TimeModule.SetNewTimeScale(Const.SlowTimeModificator);
            }
            else
            {
                _reusableServiceLocator.TimeModule.SetNewTimeScale(Const.NormalTimeModificator);
            }
        }
        
        
        
        

        public void Exit()
        {
            DeinitializeGameplayUI();
            UnsubscribeFromEvents();

            _reusableServiceLocator.PCInputGlobalService.OnGameplayState = false;
        }

        public void StartMenu()
        {
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.MenuState);
        }

        public void StartPause(bool isPaused)
        {
            if (isPaused)
            {
                _gameMachineModule.GameMachine.SetState(_gameMachineModule.PauseState);
            }
        }

        private void SubscribeToEvents()
        {
            _reusableServiceLocator.PCInputGlobalService.PauseEvent += StartPause;
        }

        private void UnsubscribeFromEvents()
        {
            _reusableServiceLocator.PCInputGlobalService.PauseEvent -= StartPause;
        }

        private void InitializeGameplayUI()
        {
            SetActiveState(_uiServiceLocator.UIController.HUD.GameObject(), true);
            SetActiveState(_uiServiceLocator.UIController.CursorToSprite.GameObject(), true);
        }

        private void DeinitializeGameplayUI()
        {
            SetActiveState(_uiServiceLocator.UIController.HUD.GameObject(), false);
            SetActiveState(_uiServiceLocator.UIController.CursorToSprite.GameObject(), false);
        }

        private void CreatePlayer()
        {
            _managersServiceLocator.PlayerHandler?.CreatePlayer();
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

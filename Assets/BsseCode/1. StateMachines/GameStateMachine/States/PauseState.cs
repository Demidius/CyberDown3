using BsseCode._2._Services.ServiceLocator;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class PauseState : IGameState
    {
        
        private IGameMachineModule _gameMachineModule;

        private float _temtTimeSpeed;
        private IUIServiceLocator _uiServiceLocator;
        private IReusableServiceLocator _reusableServiceLocator;

        public PauseState(
            IGameMachineModule gameMachineModule, 
            IUIServiceLocator uiServiceLocator,
            IReusableServiceLocator reusableServiceLocator
            )
        {
            _reusableServiceLocator = reusableServiceLocator;
            _uiServiceLocator = uiServiceLocator;
            _gameMachineModule = gameMachineModule;
        }

        public void Enter()
        {
            _reusableServiceLocator.PCInputGlobalService.PauseEvent += ReturnToGame;
            _uiServiceLocator.UIController.PausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void ReturnToGame(bool OnOff)
        {
            if (!OnOff)
            {
                _gameMachineModule.GameMachine.SetState(_gameMachineModule.GameplayState);
            }
        }

        public void ReturnToMenu()
        {
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.MenuState);
        }

        public void Exit()
        {
            Time.timeScale = 1; 
            _uiServiceLocator.UIController.PausePanel.SetActive(false);
            _reusableServiceLocator.PCInputGlobalService.PauseEvent -= ReturnToGame;
        }
    }
}
using BsseCode._2._Services.ServiceLocator;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class FinishState : IGameState
    {
        public IGameState CurrentState;
        private GameMachineStarter _gameMachineStarter;

        private float _temtTimeSpeed;
        private IUIServiceLocator _uiServiceLocator;

        public FinishState(
            GameMachineStarter gameMachineStarter, 
            IUIServiceLocator uiServiceLocator
            )
        {
            _gameMachineStarter = gameMachineStarter;
            _uiServiceLocator = uiServiceLocator;
        }

        public void Enter()
        {
            _uiServiceLocator.UIController.FinishState.SetActive(true);
            Time.timeScale = 0;
        }

        public void Exit()
        {
            Time.timeScale = 1;
            _uiServiceLocator.UIController.FinishState.SetActive(false);
        }
    }
}
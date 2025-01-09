using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices;
using BsseCode._2._Services.ServiceLocator;
using UnityEngine;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class ResetState : IGameState
    {
        
        private GameMachineStarter _gameMachineStarter;

        private float _temtTimeSpeed;
        private IUIServiceLocator _uiServiceLocator;
        private IManagersServiceLocator _managersServiceLocator;

        public ResetState(
            GameMachineStarter gameMachineStarter, 
            IUIServiceLocator uiServiceLocator, 
            IManagersServiceLocator managersServiceLocator)
        {
            _managersServiceLocator = managersServiceLocator;
            _uiServiceLocator = uiServiceLocator;
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            _managersServiceLocator.PlayerHandler.DestroyPlayer();
            _uiServiceLocator.UIController.ResetStatePanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void ReturnToGame()
        {
            _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.LandingState);
        }

        public void Exit()
        {
            Time.timeScale = 1;
            _managersServiceLocator.PlayerHandler.CreatePlayer();
            _uiServiceLocator.UIController.ResetStatePanel.SetActive(false);
        }
    }
}
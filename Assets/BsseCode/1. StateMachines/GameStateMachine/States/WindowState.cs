using _2_NewBaseCode.BaseSceneCode._1_GameMachine;
using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices;
using BsseCode._2._Services.ServiceLocator;
using UnityEngine;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class WindowState : IGameState
    {
        private IGameMachineModule _gameMachineModule;

        private float _temtTimeSpeed;
        private IUIServiceLocator _uiServiceLocator;
        private IReusableServiceLocator _reusableServiceLocator;

        public WindowState(
            IGameMachineModule gameMachineModule, 
            IUIServiceLocator uiServiceLocator,
            IReusableServiceLocator reusableServiceLocator)
        {
            _reusableServiceLocator = reusableServiceLocator;
            _uiServiceLocator = uiServiceLocator;
            _gameMachineModule = gameMachineModule;
        }

        public void Enter()
        {
            _reusableServiceLocator.PCInputGlobalService.PauseEvent += ReturnToGame;
            _uiServiceLocator.UIController.Window1Panel.SetActive(true);
            Time.timeScale = 0;
        }

        public void ReturnToGame(bool OnOff)
        {
            if (!OnOff)
            {
                _gameMachineModule.GameMachine.SetState(_gameMachineModule.GameplayState);
            }
        }

        public void Exit()
        {
            Time.timeScale = 1;
            _uiServiceLocator.UIController.Window1Panel.SetActive(false);
            _reusableServiceLocator.PCInputGlobalService.PauseEvent -= ReturnToGame;
        }
    }
}
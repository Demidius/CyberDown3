
using NewBaseCode.UI;
using UnityEngine;

namespace NewBaseCode._1._GameMachine.States
{
    public class MainMenuState : IGameState
    {
        private IGameMachineModule _gameMachineModule;
        private IMenuPanelsController _menuPanelsController;

        public MainMenuState(IGameMachineModule gameMachineModule, IMenuPanelsController menuPanelsController)
        {
            _gameMachineModule = gameMachineModule;
            _menuPanelsController = menuPanelsController;
        }


        public void Enter()
        {
            _menuPanelsController.EnterOnMenu();
        }

        public void Exit()
        {
            
        }
    }
}

using NewBaseCode._3._UI._1.Controllers;
using NewBaseCode._4._Audio;

namespace NewBaseCode._1._GameMachine.States
{
    public class MainMenuState : IGameState
    {
        private IGameMachineModule _gameMachineModule;
        private readonly IMenuPanelsController _menuPanelsController;
        private readonly IMusicController _musicController;

        public MainMenuState(
            IGameMachineModule gameMachineModule, 
            IMenuPanelsController menuPanelsController, 
            IMusicController musicController)
        {
            _musicController = musicController;
            _gameMachineModule = gameMachineModule;
            _menuPanelsController = menuPanelsController;
        }


        public void Enter()
        {
            _menuPanelsController.CloseAllPanels();
            _menuPanelsController.EnterOnMenu();
            _musicController.StartMenuMusic();
        }

        public void Exit()
        {
            _musicController.StopMenuMusic();
        }
    }
}
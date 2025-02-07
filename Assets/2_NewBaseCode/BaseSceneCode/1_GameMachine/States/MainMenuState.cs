using _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol;
using _2_NewBaseCode.BaseSceneCode._3._UI._1.Controllers;
using _2_NewBaseCode.BaseSceneCode._4._Audio;

namespace _2_NewBaseCode.BaseSceneCode._1_GameMachine.States
{
    public class MainMenuState : IGameState
    {
        private IGameMachineModule _gameMachineModule;
        private readonly IMenuPanelsController _menuPanelsController;
        private readonly IMusicController _musicController;
        private IInputController _inputController;

        public MainMenuState
        (
            IGameMachineModule gameMachineModule,
            IMenuPanelsController menuPanelsController,
            IMusicController musicController,
            IInputController inputController
        )
        {
            _inputController = inputController;
            _musicController = musicController;
            _gameMachineModule = gameMachineModule;
            _menuPanelsController = menuPanelsController;
        }
        
        public void Enter()
        {
            StateInitialize();
            
        }

        public void Update()
        {
            
        }

        private void StateInitialize()
        {
            _menuPanelsController.ActivateMenuPanels();
            _musicController.StartMenuMusic();
            
            _inputController.UIOnEnable();
            _inputController.GameplayOnDisable();
        }

        public void Exit()
        {
            _musicController.StopMenuMusic();
            _menuPanelsController.DeactivateMenuPanels();
        }
    }
}
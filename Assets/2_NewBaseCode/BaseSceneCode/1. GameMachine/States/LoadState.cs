using _2_NewBaseCode.BaseSceneCode._3._UI._1.Controllers;

namespace _2_NewBaseCode.BaseSceneCode._1._GameMachine.States
{
    public class LoadState : IGameState
        {
        private IGameMachineModule _gameMachineModule;
        private ILoadPanelController _loadPanelController;

        public LoadState (IGameMachineModule gameMachineModule, ILoadPanelController loadPanelController)
        {
            _loadPanelController = loadPanelController;
            _gameMachineModule = gameMachineModule;
        }

        public void Enter()
        {
            _loadPanelController.EnterOnLoadPanel();
            // _gameMachineModule.GameMachine.SetState(_gameMachineModule.MenuState);
        }

        public void Exit()
        {
            _loadPanelController.ExitOnLoadPanel();

        }
    }
}
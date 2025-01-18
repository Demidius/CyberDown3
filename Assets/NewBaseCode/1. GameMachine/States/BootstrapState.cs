using BsseCode._1._StateMachines.GameStateMachine;

namespace NewBaseCode._1._GameMachine.States
{
    public class BootstrapState : IGameState
        {
        private IGameMachineModule _gameMachineModule;
        public BootstrapState (IGameMachineModule gameMachineModule)
        {
            _gameMachineModule = gameMachineModule;
        }

        public void Enter()
        {
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.MenuState);
        }

        public void Exit()
        {
           
        }
    }
}
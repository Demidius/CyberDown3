using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class BootstrapState : IGameState
    {
        private IGameMachineModule _gameMachineModule;
        public BootstrapState(IGameMachineModule gameMachineModule)
        {
            _gameMachineModule = gameMachineModule;
        }

        public void Enter()
        {
            _gameMachineModule.Machine.SetState(_gameMachineModule.MenuState);
        }

        public void Exit()
        {
           
        }
    }
}
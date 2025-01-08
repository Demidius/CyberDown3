using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class BootstrapState : IGameState
    {
        private GameMachineStarter _gameMachineStarter;
        public BootstrapState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.MainMenuState);
        }

        public void Exit()
        {
           
        }
    }
}
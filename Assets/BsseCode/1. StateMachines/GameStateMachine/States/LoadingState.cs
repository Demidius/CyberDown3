

using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class LoadingState : IGameState
    {
        
        private GameMachineStarter _gameMachineStarter;

        public LoadingState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }
        public void Enter()
        {
           Debug.Log("LoadingState: Enter");
        }

        public void Exit()
        {
            
        }
    }
}
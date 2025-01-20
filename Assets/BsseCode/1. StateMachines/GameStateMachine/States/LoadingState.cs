using _2_NewBaseCode.BaseSceneCode._1._GameMachine;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class LoadingState : IGameState
    {
        
        private IGameMachineModule _gameMachineModule;

        public LoadingState(IGameMachineModule gameMachineModule)
        {
            _gameMachineModule = gameMachineModule;
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
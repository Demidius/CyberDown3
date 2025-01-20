using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._1._GameMachine.States
{
    public class GameState : IGameState
        {
        private IGameMachineModule _gameMachineModule;
        
        public GameState (IGameMachineModule gameMachineModule)
        {
            _gameMachineModule = gameMachineModule;
        }

        public void Enter()
        {
           Debug.Log("Enter Game State");
        }

        public void Exit()
        {
           
        }
    }
}
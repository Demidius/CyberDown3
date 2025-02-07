using _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._1_GameMachine.States
{
    public class GameState : IGameState
        {
        private IGameMachineModule _gameMachineModule;
        private IStateSwitcher _stateSwitcher;
        private IInputController _inputController;

        public GameState (
            IGameMachineModule gameMachineModule,
            IStateSwitcher stateSwitcher,
            IInputController inputController
            )
        {
            _inputController = inputController;
            _stateSwitcher = stateSwitcher;
            _gameMachineModule = gameMachineModule;
        }

        public void Enter()
        {
            StateInitialize();
           Debug.Log("Enter Game State");
           _inputController.GameplayOnEnable();
        }

        private void EscapeOnPause()
        {
            _stateSwitcher.SetPauseState();
        }

        public void Update()
        {
            
        }

        private void StateInitialize()
        {
          
        }

        public void Exit()
        {
           
        }
    }
}
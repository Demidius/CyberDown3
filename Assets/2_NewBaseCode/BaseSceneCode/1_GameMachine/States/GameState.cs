using _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._1_GameMachine.States
{
    public class GameState : IGameState
        {
        private IGameMachineModule _gameMachineModule;
        private IInputSwitcher _inputSwitcher;
        private IInputService _inputService;
        private IStateSwitcher _stateSwitcher;

        public GameState (
            IGameMachineModule gameMachineModule,
            IInputSwitcher inputSwitcher,
            IInputService inputService,
            IStateSwitcher stateSwitcher
            )
        {
            _stateSwitcher = stateSwitcher;
            _inputService = inputService;
            _inputSwitcher = inputSwitcher;
            _gameMachineModule = gameMachineModule;
        }

        public void Enter()
        {
            StateInitialize();
           Debug.Log("Enter Game State");
           _inputService.EscapeKeyDown += EscapeOnPause;
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
            _inputSwitcher.SetGameInput();
            _inputService.EscapeKeyDown -= EscapeOnPause;
        }

        public void Exit()
        {
           
        }
    }
}
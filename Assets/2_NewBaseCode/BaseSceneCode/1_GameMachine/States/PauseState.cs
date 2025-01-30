using _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol;
using _2_NewBaseCode.BaseSceneCode._3._UI._1.Controllers;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._1_GameMachine.States
{
    public class PauseState : IGameState
    {
        private IGameMachineModule _gameMachineModule;
        private IInputSwitcher _inputSwitcher;
        private IInputService _inputService;
        private IStateSwitcher _stateSwitcher;
        private IPausePanelController _pausePanelController;

        public PauseState(
            IGameMachineModule gameMachineModule,
            IInputSwitcher inputSwitcher,
            IInputService inputService,
            IStateSwitcher stateSwitcher,
            IPausePanelController pausePanelController
        )
        {
            _pausePanelController = pausePanelController;
            _stateSwitcher = stateSwitcher;
            _inputService = inputService;
            _inputSwitcher = inputSwitcher;
            _gameMachineModule = gameMachineModule;
        }

        public void Enter()
        {
            Debug.Log("Pause State Enter");
            
            StateInitialize();
            
            _inputService.EscapeKeyDown += EscapeOnGame;
        }
        private void EscapeOnGame()
        {
            _stateSwitcher.SetGameplayState();
        }
        public void Update()
        {
            
        }

        private void StateInitialize()
        {
            _inputSwitcher.SetPauseInput();
            _pausePanelController.EnterOnPausePanel();
            Time.timeScale = 0f;
        }

        public void Exit()
        {
            _inputService.EscapeKeyDown -= EscapeOnGame;
            _pausePanelController.ExitOnPausePanel();
            Time.timeScale = 1f;
        }
    }
}
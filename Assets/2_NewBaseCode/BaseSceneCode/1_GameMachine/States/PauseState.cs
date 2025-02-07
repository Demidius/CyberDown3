using _2_NewBaseCode.BaseSceneCode._3._UI._1.Controllers;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._1_GameMachine.States
{
    public class PauseState : IGameState
    {
        private IGameMachineModule _gameMachineModule;
        private IStateSwitcher _stateSwitcher;
        private IPausePanelController _pausePanelController;

        public PauseState(
            IGameMachineModule gameMachineModule,
            IStateSwitcher stateSwitcher,
            IPausePanelController pausePanelController
        )
        {
            _pausePanelController = pausePanelController;
            _stateSwitcher = stateSwitcher;
            _gameMachineModule = gameMachineModule;
        }

        public void Enter()
        {
            Debug.Log("Pause State Enter");
            
            StateInitialize();
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
            _pausePanelController.EnterOnPausePanel();
            Time.timeScale = 0f;
        }

        public void Exit()
        {
            _pausePanelController.ExitOnPausePanel();
            Time.timeScale = 1f;
        }
    }
}
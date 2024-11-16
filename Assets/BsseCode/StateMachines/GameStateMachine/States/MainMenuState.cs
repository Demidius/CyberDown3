using BsseCode.Constants;
using UnityEngine;

namespace BsseCode.StateMachines.GameStateMachine.States
{
    public class MainMenuState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;

        public MainMenuState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            Debug.Log("Главное меню: ожидание выбора игрока");
        }

        public void StartGame()
        {
            _gameStateMachine.SetState(new LoadLevelState(_gameStateMachine, Const.Game));
        }

        public void Exit()
        {
           
        }
    }
}
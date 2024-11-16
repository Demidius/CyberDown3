using BsseCode.Constants;
using UnityEngine;

namespace BsseCode.StateMachines.GameStateMachine.States
{
    public class GameplayState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;

        public GameplayState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {
            Debug.Log("Gameplay: Начало игрового процесса");
        }
        
        public void Exit() { }

        public void StartMenu()
        {
            _gameStateMachine.SetState(new LoadLevelState(_gameStateMachine, Const.Menu));
        }
        public void EndGame()
        {
            _gameStateMachine.SetState(new GameOverState(_gameStateMachine));
        }
    }
}
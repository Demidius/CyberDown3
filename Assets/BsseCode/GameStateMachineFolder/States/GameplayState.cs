using UnityEngine;

namespace BsseCode.GameStateMachineFolder.States
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

        public void EndGame()
        {
            // Завершение игры, переход к GameOverState
            _gameStateMachine.SetState(new GameOverState(_gameStateMachine));
        }
    }
}
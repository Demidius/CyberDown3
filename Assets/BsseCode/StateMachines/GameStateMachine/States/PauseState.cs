using UnityEngine;

namespace BsseCode.StateMachines.GameStateMachine.States
{
    public class PauseState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;

        public PauseState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            Debug.Log("Игра на паузе");
            Time.timeScale = 0; // Остановка времени
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            _gameStateMachine.SetState(new GameplayState(_gameStateMachine));
        }

        public void Exit()
        {
            Time.timeScale = 1; // Возвращение времени к нормальному состоянию
        }
    }
}
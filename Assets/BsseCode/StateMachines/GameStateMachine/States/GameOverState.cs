using UnityEngine;

namespace BsseCode.StateMachines.GameStateMachine.States
{
    public class GameOverState : IGameState
    {
        public GameOverState(GameStateMachine gameStateMachine) { }

        public void Enter()
        {
            Debug.Log("Игра завершена. GameOverState");
            // Здесь можно показать экран завершения, перезапустить игру или выйти
        }

        public void Exit() { }
    }
}
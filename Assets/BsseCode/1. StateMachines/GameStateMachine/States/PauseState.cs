using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class PauseState : IGameState
    {
        public IGameState CurrentState;
        private GameMachineStarter _gameMachineStarter;

        public PauseState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            Debug.Log("Игра на паузе");
            Time.timeScale = 0; // Остановка времени
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            // _gameStateMachine.SetState(new GameplayState(_gameStateMachine));
        }

        public void Exit()
        {
            Time.timeScale = 1; // Возвращение времени к нормальному состоянию
        }
    }
}
using BsseCode.Constants;
using UnityEngine;

namespace BsseCode.GameStateMachine.States
{
    public class BootstrapState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;

        public BootstrapState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            Debug.Log("Bootstrap: Инициализация игры");

           _gameStateMachine.SetState(new LoadLevelState(_gameStateMachine, Constans.GameEnterLevel));
        }

        public void Exit()
        {
            // Очистка данных, если необходимо
        }

       
    }

   
}
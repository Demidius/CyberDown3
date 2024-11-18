using BsseCode.Constants;
using UnityEngine;

namespace BsseCode.StateMachines.GameStateMachine.States
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

           _gameStateMachine.SetState(new LoadLevelState(_gameStateMachine, Const.Menu));
           
        }

        public void Exit()
        {
            // Очистка данных, если необходимо
        }

       
    }

   
}
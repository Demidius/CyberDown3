using System;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class GameOverState : IGameState
    {
        private GameMachineStarter _gameMachineStarter;
       
        public GameOverState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            Debug.Log("Игра завершена. GameOverState");
            // Здесь можно показать экран завершения, перезапустить игру или выйти
            
        }

        public void Exit()
        {
        }
    }
}
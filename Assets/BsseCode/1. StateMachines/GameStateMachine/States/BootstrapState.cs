using BsseCode._2._Services.GlobalServices.Addressable;
using BsseCode._3._SupportCode.Constants;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class BootstrapState : IGameState
    {
        private GameMachineStarter _gameMachineStarter;

        public BootstrapState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            Debug.Log("Bootstrap: Инициализация игры");
            _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.MainMenuState);
        }

        public void Exit()
        {
            // Очистка данных, если необходимо
        }
    }
}
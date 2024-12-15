using BsseCode._3._SupportCode.Constants;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class MainMenuState : IGameState
    {
        private GameMachineStarter _gameMachineStarter;

        public MainMenuState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            Debug.Log("Главное меню: ожидание выбора игрока");
            // Логика для отображения главного меню, например, ожидание нажатия кнопки "Начать игру"
        }

        

        public void Exit()
        {
            // Очистка данных, если необходимо
        }
    }
}
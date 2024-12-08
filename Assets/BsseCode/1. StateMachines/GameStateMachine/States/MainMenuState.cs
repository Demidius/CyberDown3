using BsseCode._3._SupportCode.Constants;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class MainMenuState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;

        public MainMenuState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            Debug.Log("Главное меню: ожидание выбора игрока");
            // Логика для отображения главного меню, например, ожидание нажатия кнопки "Начать игру"
        }

        public void StartGame()
        {
            // Переход к загрузке уровня
            _gameStateMachine.SetState(new LoadLevelState(_gameStateMachine, Const.Game));
        }

        public void Exit()
        {
            // Очистка данных, если необходимо
        }
    }
}
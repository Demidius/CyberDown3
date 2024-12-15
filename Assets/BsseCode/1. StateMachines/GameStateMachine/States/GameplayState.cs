using System;
using BsseCode._3._SupportCode.Constants;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class GameplayState : IGameState
    {
        private GameMachineStarter _gameMachineStarter;
        public event Action OnGameState;
        public GameplayState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            Debug.Log("Gameplay: Начало игрового процесса");
            // _gameMachineStarter.AddressableSceneLoader.LoadLevelByIndex(0);\
            OnGameState?.Invoke();
        }

        public void Exit()
        {
            
        }

        public void StartMenu()
        {
            // Переход к загрузке уровня
            
            // _gameStateMachine.SetState(new LoadLevelState(_gameStateMachine, Const.Menu));
        }

        public void EndGame()
        {
            // Завершение игры, переход к GameOverState
            // _gameStateMachine.SetState(new GameOverState(_gameStateMachine));
        }
    }
}
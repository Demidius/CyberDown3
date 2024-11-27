using BsseCode.Constants;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace BsseCode.StateMachines.GameStateMachine.States
{
    public class GameplayState : IGameState
    {
        private Bus masterBus;
        private readonly GameStateMachine _gameStateMachine;

        public GameplayState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {
            Debug.Log("Gameplay: Начало игрового процесса");
            masterBus = RuntimeManager.GetBus("bus:/");
        }

        public void Exit()
        {
            StopAllSounds();
        }

        public void StartMenu()
        {
            // Переход к загрузке уровня
            _gameStateMachine.SetState(new LoadLevelState(_gameStateMachine, Const.Menu));
        }
        
        public void EndGame()
        {
           
            // Завершение игры, переход к GameOverState
            _gameStateMachine.SetState(new GameOverState(_gameStateMachine));
        }
        public void StopAllSounds()
        {
            // Останавливаем все звуки, относящиеся к Master Bus
            masterBus.stopAllEvents(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}
using BsseCode.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BsseCode.StateMachines.GameStateMachine.States
{
    public class LoadLevelState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly string _levelName;

        public LoadLevelState(GameStateMachine gameStateMachine, string levelName)
        {
            _gameStateMachine = gameStateMachine;
            _levelName = levelName;
        }

        public void Enter()
        {
            SceneManager.LoadSceneAsync(_levelName).completed += OnLevelLoaded;
        }

        private void OnLevelLoaded(AsyncOperation obj)
        {
            if (_levelName == Const.Menu)
                _gameStateMachine.SetState(new MainMenuState(_gameStateMachine));
            else
                _gameStateMachine.SetState(new GameplayState(_gameStateMachine));
        }

        public void Exit()
        {
            
        }
    }
}
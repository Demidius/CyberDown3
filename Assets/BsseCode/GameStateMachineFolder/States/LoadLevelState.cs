using UnityEngine;
using UnityEngine.SceneManagement;

namespace BsseCode.GameStateMachineFolder.States
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
            Debug.Log($"Загрузка уровня: {_levelName}");
            SceneManager.LoadSceneAsync(_levelName).completed += OnLevelLoaded;
        }

        private void OnLevelLoaded(AsyncOperation obj)
        {
            // Переходим к игровому процессу после загрузки уровня
            _gameStateMachine.SetState(new GameplayState(_gameStateMachine));
        }

        public void Exit()
        {
            // Очистка данных, если необходимо
        }
    }
}
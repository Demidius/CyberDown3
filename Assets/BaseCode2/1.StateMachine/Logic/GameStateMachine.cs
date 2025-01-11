using System;
using UnityEngine;

namespace BaseCode2._1.StateMachine.Logic
{
    public class GameStateMachine : MonoBehaviour, IGameStateMachine
    {
        private IGameState _currentState;

        public event Action<IGameState> OnSceneChanged;

        public void SetState(IGameState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();

            // Предполагаем, что IGameState содержит SceneName
            OnSceneChanged?.Invoke(newState);
            Debug.Log($"Переключились на сцену: {newState}");
        }
    }


    public interface IGameStateMachine
    {
        event Action<IGameState> OnSceneChanged;
        void SetState(IGameState newState);
    }
}
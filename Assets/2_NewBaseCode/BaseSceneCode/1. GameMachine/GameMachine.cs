using System;
using Debug = UnityEngine.Debug;

namespace _2_NewBaseCode.BaseSceneCode._1._GameMachine
{
    public interface IGameMachine
    {
        void StartStateMachine();
        void SetState(IGameState newState);

        public event Action<IGameState> EnterInState;
    }

    public class GameMachine : IGameMachine
    {
        private IGameState _currentState;
        private IGameMachineModule _gameMachineModule;
        public event Action<IGameState> EnterInState;

        public GameMachine(IGameMachineModule gameMachineModule)
        {
            _gameMachineModule = gameMachineModule;
        }

        public void StartStateMachine()
        {
            SetState(_gameMachineModule.BootstrapState);
        }

        public void SetState(IGameState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();

            Debug.Log("In state " + _currentState.GetType().Name);
            
            EnterInState?.Invoke(_currentState);
        }
    }
}
using System;
using Debug = UnityEngine.Debug;

namespace _2_NewBaseCode.BaseSceneCode._1_GameMachine
{
    public interface IGameMachine
    {
        public IGameState CurrentState { get; }
        void StartStateMachine();
        void SetState(IGameState newState);

        public event Action<IGameState> EnterInState;
    }

    public class GameMachine : IGameMachine
    {
        public IGameState CurrentState { get; private set; }
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
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();

            Debug.Log("In state " + CurrentState.GetType().Name);
            
            EnterInState?.Invoke(CurrentState);
        }
    }
}
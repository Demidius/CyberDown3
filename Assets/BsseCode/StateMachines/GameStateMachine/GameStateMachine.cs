using BsseCode.StateMachines.GameStateMachine.States;

namespace BsseCode.StateMachines.GameStateMachine
{
    public class GameStateMachine
    {
        private IGameState _currentState;
    
        public void SetState(IGameState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        public void Start()
        {
            // Запускаем машину состояний с BootstrapState
            SetState(new BootstrapState(this));
        }
    }
}
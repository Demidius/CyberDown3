using BsseCode._1._StateMachines.GameStateMachine.States;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine
{
    public class GameStateMachine
    {
        private IGameState _currentState;
        private GameMachineStarter _starter;

        public GameStateMachine(GameMachineStarter starter)
        {
            _starter = starter;
        }
       
        public void Start()
        {
            SetState(_starter.BootstrapState);
        }

        public void SetState(IGameState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}
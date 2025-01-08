using BsseCode._1._StateMachines.GameStateMachine.States;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine
{
    public class GameStateMachine
    {
        private IGameState _currentState;
        private GameMachineStarter _gameMachineStarter;

        public GameStateMachine(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }
       
        public void StartStateMachine()
        {
            SetState(_gameMachineStarter.BootstrapState);
        }

        public void SetState(IGameState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}
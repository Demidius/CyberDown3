using BaseCode2._1.StateMachine.Logic;
using Zenject;

namespace BaseCode2._1.StateMachine.GameStates
{
    public class Base_BootstrapState : IGameState
    {
        private IGameStateMachine _gameStateMachine;
        private Base_MainMenuState _mainMenuState;

        [Inject]
        public void Construct(
            IGameStateMachine gameStateMachine,
            Base_MainMenuState mainMenuState
        )
        {
            _mainMenuState = mainMenuState;
            _gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {
           _gameStateMachine.SetState(_mainMenuState);
        }

        public void Exit()
        {
            
        }
    }
}
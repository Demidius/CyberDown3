using BaseCode2._1.StateMachine.GameStates;
using UnityEngine;
using Zenject;

namespace BaseCode2._1.StateMachine.Logic
{
    public class GameStarter : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private Base_BootstrapState _baseBootstrapState;

        [Inject]
        public void Construct(
            GameStateMachine gameStateMachine, 
            Base_BootstrapState baseBootstrapState
           )
        {
            _baseBootstrapState = baseBootstrapState;
            _gameStateMachine = gameStateMachine;
        }


        private void Awake()
        {
            _gameStateMachine.SetState(_baseBootstrapState);
        }
    }
}
using BsseCode.StateMachines.GameStateMachine;
using UnityEngine;
using Zenject;

namespace BsseCode
{
    public class GameManager : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _gameStateMachine.Start();
        }
    }
}
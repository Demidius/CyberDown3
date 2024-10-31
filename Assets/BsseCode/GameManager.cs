using UnityEngine;
using Zenject;
using BsseCode.GameStateMachineFolder;

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
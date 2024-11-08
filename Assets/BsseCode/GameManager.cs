using UnityEngine;
using Zenject;

namespace BsseCode
{
    public class GameManager : MonoBehaviour
    {
        private GameStateMachine.GameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(GameStateMachine.GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _gameStateMachine.Start();
        }
    }
}
using UnityEngine;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine
{
    public class GameMachineStarter : MonoBehaviour
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
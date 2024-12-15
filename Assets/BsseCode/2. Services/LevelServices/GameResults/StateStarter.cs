using BsseCode._1._StateMachines.GameStateMachine;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.LevelServices.GameResults
{
    public class StateStarter : MonoBehaviour
    {
        private GameMachineStarter _starter;

        [Inject]
        void Construct(GameMachineStarter starter)
        {
            _starter = starter;
        }

        void Start()
        {
            _starter.GameStateMachine.SetState(_starter.GameplayState);
        }
    }
}
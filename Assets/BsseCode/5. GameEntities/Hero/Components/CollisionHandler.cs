using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._1._StateMachines.GameStateMachine.States;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._5._GameEntities.Objects.Enemy;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Hero.Components
{
    public class CollisionHandler : MonoBehaviour
    {
        
        private KillsController _killsController;
        private GameMachineStarter _starter;

        [Inject]
        public void Construct(GameMachineStarter starter, KillsController killsController )
        {
            _starter = starter;
            _killsController = killsController;
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                _killsController.EndGame();
                _starter.GameStateMachine.SetState(_starter.BootstrapState);
            }
        }
    }
}
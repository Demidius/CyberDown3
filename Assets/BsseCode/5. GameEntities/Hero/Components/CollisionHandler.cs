using BsseCode._1._StateMachines.GameStateMachine.States;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._5._GameEntities.Objects.Enemy;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Hero.Components
{
    public class CollisionHandler : MonoBehaviour
    {
        private GameplayState _gameplayState;
        private KillsController _killsController;

        [Inject]
        public void Construct(GameplayState gameplayState, KillsController killsController )
        {
            _killsController = killsController;
            _gameplayState = gameplayState;
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                _killsController.EndGame();
                _gameplayState.StartMenu();
            }
        }
    }
}
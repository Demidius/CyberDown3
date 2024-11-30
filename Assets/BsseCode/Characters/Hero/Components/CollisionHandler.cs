using BsseCode.Mechanics.GameResults;
using BsseCode.Pools.Pools.EnemesPool;
using BsseCode.StateMachines.GameStateMachine.States;
using UnityEngine;
using Zenject;

namespace BsseCode.Caracters.Hero.Components
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
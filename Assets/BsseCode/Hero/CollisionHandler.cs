using System;
using BsseCode.Pools.Pools.EnemesPool;
using BsseCode.StateMachines.GameStateMachine.States;
using UnityEngine;
using Zenject;

namespace BsseCode.Hero
{
    public class CollisionHandler : MonoBehaviour
    {
        private GameplayState _gameplayState;

        [Inject]
        public void Construct(GameplayState gameplayState)
        {
            _gameplayState = gameplayState;
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                _gameplayState.StartMenu();
            }
        }
    }
}
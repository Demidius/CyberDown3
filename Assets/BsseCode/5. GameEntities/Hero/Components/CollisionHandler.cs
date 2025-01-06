using System.Collections.Generic;
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._5._GameEntities.Objects.Enemy;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Hero.Components
{
    public class CollisionHandler : MonoBehaviour
    {
        private GameMachineStarter _gameMachineStarter;

        [Inject]
        public void Construct(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.ResetState);
            }
        }
        
       
    }
}
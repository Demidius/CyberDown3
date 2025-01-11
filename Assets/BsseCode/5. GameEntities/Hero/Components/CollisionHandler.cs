using System.Collections.Generic;
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._5._GameEntities.Objects.Enemy;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Hero.Components
{
    public class CollisionHandler : MonoBehaviour
    {
        private IGameMachineModule _gameMachineModule;

        [Inject]
        public void Construct(IGameMachineModule gameMachineModule)
        {
            _gameMachineModule = gameMachineModule;
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                _gameMachineModule.Machine.SetState(_gameMachineModule.ResetState);
            }
        }
        
       
    }
}

using _2_NewBaseCode.BaseSceneCode._1._GameMachine;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode.Entites.Hero.Components
{
    public class CollisionHandler : MonoBehaviour
    {
        private IGameMachineModule _gameMachineModule;

        [Inject]
        public void Construct(IGameMachineModule gameMachineModule)
        {
            _gameMachineModule = gameMachineModule;
        }

        // private void OnTriggerEnter2D(Collider2D other) 
        // {
        //     if (other.TryGetComponent<Enemy>(out Enemy enemy))
        //     {
        //         // _gameMachineModule.GameMachine.SetState(_gameMachineModule.ResetState);
        //     }
        // }
        
       
    }
}
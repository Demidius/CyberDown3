using System;
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.GlobalServices.Pools;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.AfterDeathMarks
{
    public class AfterDeathMarks : MonoBehaviour, IPoolsElement
    {
        private IPoolController _poolController;
        private IGameMachineModule _gameMachineModule;


        [Inject]
        public void Construct(IPoolController poolController, IGameMachineModule gameMachineModule)
        {
            _gameMachineModule = gameMachineModule;
            _poolController = poolController;

            _gameMachineModule.MenuState.OnMenuState += ReturnToPool;
        }


        public void ReturnToPool()
        {
            _poolController.ReturnToPool(this);
        }

        private void OnDestroy()
        {
            _gameMachineModule.MenuState.OnMenuState -= ReturnToPool;
        }

       
    }
}
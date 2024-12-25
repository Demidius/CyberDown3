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
        private GameMachineStarter _gameMachineStarter;


        [Inject]
        public void Construct(IPoolController poolController, GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
            _poolController = poolController;

            _gameMachineStarter.MainMenuState.OnMenuState += Kill;
        }


        public void Kill()
        {
            _poolController.ReturnToPool(this);
        }

        private void OnDestroy()
        {
            _gameMachineStarter.MainMenuState.OnMenuState -= Kill;
        }
    }
}
using System.Collections;
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.LevelServices.BulletCounter;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.TimeProvider
{
    public class EnergyDrainHandler : MonoBehaviour
    {
     
        private IEnergyCounter _energyCounter;
        private bool _isCoroutineRunning;
        private IGameMachineModule _gameMachineModule;

        [Inject]
        public void Construct(IGameMachineModule gameMachineModule, IEnergyCounter energyCounter)
        {
            _gameMachineModule = gameMachineModule;
            _energyCounter = energyCounter;
        }

        private void Update()
        {
            if (_gameMachineModule.GameplayState.SlowMotionTimeIsActive && !_isCoroutineRunning)
            {
                StartCoroutine(ConditionCoroutine());
            }
        }
        
        IEnumerator ConditionCoroutine()
        {
            _isCoroutineRunning = true;
            while (_gameMachineModule.GameplayState.SlowMotionTimeIsActive)
            {
                EnergyDrain();
                yield return new WaitForSeconds(0.1f); 
            }
            _isCoroutineRunning = false;
        }

        private void EnergyDrain()
        {
            _energyCounter.SubtractEnergy(0.1f);
        }
        
    }
}
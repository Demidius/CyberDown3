using System.Collections;
using BsseCode._2._Services.LevelServices.BulletCounter;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.TimeProvider
{
    public class EnergyDrainHandler : MonoBehaviour
    {
        private TimeController _timeController;
        private IEnergyCounter _energyCounter;
        private bool _isCoroutineRunning;

        [Inject]
        public void Construct(TimeController timeController, IEnergyCounter energyCounter)
        {
            _energyCounter = energyCounter;
            _timeController = timeController;
        }

        private void Update()
        {
            if (_timeController.IsSlowMotion && !_isCoroutineRunning)
            {
                StartCoroutine(ConditionCoroutine());
            }
        }
        
        IEnumerator ConditionCoroutine()
        {
            _isCoroutineRunning = true;
            while (_timeController.IsSlowMotion)
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
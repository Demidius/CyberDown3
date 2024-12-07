using BsseCode.Constants;
using BsseCode.Mechanics.BulletCounter;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;
using FMODUnity;

namespace BsseCode.Services.TimeProvider
{
    public class TimeController : MonoBehaviour
    {
        private ITimeService _timeService;
        public bool IsSlowMotion { get; private set; }
        private IInputService _inputService;
        private IEnergyCounter _energyCounter;

        [Inject]
        public void Construct(ITimeService timeService, IInputService inputService, IEnergyCounter energyCounter)
        {
            _energyCounter = energyCounter;
            _inputService = inputService;
            _timeService = timeService;
        }

        private void Start()
        {
            ResetIsSlowMotion();
            _inputService.ToggleTimeEvent += ToggleTimeScale;
            _energyCounter.EnergyBarIsEmpty += ExitFromSlowMotion;
        }

        public void ResetIsSlowMotion()
        {
            IsSlowMotion = false;
        }

        private void Update()
        {
            _inputService.ToggleTimeScaleInput();
        }

        private void ToggleTimeScale()
        {
            _timeService.TimeScale = IsSlowMotion ? Const.NormalTimeSpeed : Constants.Const.SlowTimeModificator;
            if (Mathf.Approximately(_timeService.TimeScale, Const.NormalTimeSpeed))
            {
                IsSlowMotion = false;
            }
            else
            {
                IsSlowMotion = true;
            } 
        }

        private void ExitFromSlowMotion()
        {
            _timeService.TimeScale = Const.NormalTimeSpeed;
            IsSlowMotion = false;
        }


        private void OnDestroy()
        {
            // Отписываемся от события
            _inputService.ToggleTimeEvent -= ToggleTimeScale;
        }
    }
}
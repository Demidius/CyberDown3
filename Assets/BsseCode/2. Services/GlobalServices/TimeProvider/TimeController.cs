using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.LevelServices.BulletCounter;
using BsseCode._3._SupportCode.Constants;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.TimeProvider
{
    public class TimeController : MonoBehaviour
    {
        private ITimeGlobalService _timeGlobalService;
        public bool IsSlowMotion { get; private set; }
        private IInputGlobalService _inputGlobalService;
        private IEnergyCounter _energyCounter;

        [Inject]
        public void Construct(ITimeGlobalService timeGlobalService, IInputGlobalService inputGlobalService, IEnergyCounter energyCounter)
        {
            _energyCounter = energyCounter;
            _inputGlobalService = inputGlobalService;
            _timeGlobalService = timeGlobalService;
        }

        private void Start()
        {
            ResetIsSlowMotion();
            _inputGlobalService.ToggleTimeEvent += ToggleTimeScale;
            _energyCounter.OnEnergyBarEmpty += ExitFromSlowMotion;
        }

        public void ResetIsSlowMotion()
        {
            IsSlowMotion = false;
        }

        private void Update()
        {
            _inputGlobalService.ToggleTimeScaleInput();
        }

        private void ToggleTimeScale()
        {
            _timeGlobalService.TimeScale = IsSlowMotion ? Const.NormalTimeSpeed : Const.SlowTimeModificator;
            if (Mathf.Approximately(_timeGlobalService.TimeScale, Const.NormalTimeSpeed))
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
            _timeGlobalService.TimeScale = Const.NormalTimeSpeed;
            IsSlowMotion = false;
        }


        private void OnDestroy()
        {
            // Отписываемся от события
            _inputGlobalService.ToggleTimeEvent -= ToggleTimeScale;
        }
    }
}
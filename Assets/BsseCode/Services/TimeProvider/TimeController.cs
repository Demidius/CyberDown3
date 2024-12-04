using BsseCode.Constants;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;
using FMODUnity;

namespace BsseCode.Services.TimeProvider
{
    public class TimeController : MonoBehaviour
    {
        private ITimeService _timeService;
        private bool _isSlowMotion;
        private IInputService _inputService;

        [Inject]
        public void Construct(ITimeService timeService, IInputService inputService)
        {
            _inputService = inputService;
            _timeService = timeService;
        }

        private void Start()
        {
            ResetIsSlowMotion();
            _inputService.ToggleTimeEvent += ToggleTimeScale;
        }

        public void ResetIsSlowMotion()
        {
            _isSlowMotion = false;
        }

        private void Update()
        {
            _inputService.ToggleTimeScaleInput();
        }

        private void ToggleTimeScale()
        {
            _timeService.TimeScale = _isSlowMotion ? 1f : Constants.Const.SlowTimeModificator;
            _isSlowMotion = !_isSlowMotion;
            
        }


        private void OnDestroy()
        {
            // Отписываемся от события
            _inputService.ToggleTimeEvent -= ToggleTimeScale;
            
        }
    }
}

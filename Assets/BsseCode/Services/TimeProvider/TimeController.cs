using BsseCode.Constants;
using BsseCode.Services.InputFol;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

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
            _inputService.ToggleTimeEvent += ToggleTimeScale;
        }
        
        private void Update()
        {
          _inputService.ToggleTimeScaleInput();
        }

        private void ToggleTimeScale()
        {
            _timeService.TimeScale = _isSlowMotion ? 1f : Constans.SlowTimeModificator;
            _isSlowMotion = !_isSlowMotion;
        }

        private void OnDestroy()
        {
            _inputService.ToggleTimeEvent -= ToggleTimeScale;
        }
    }
}
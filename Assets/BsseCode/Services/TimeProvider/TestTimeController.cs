using BsseCode.Services.InputFol;
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ToggleTimeScale();
            }
        }

        private void ToggleTimeScale()
        {
            _timeService.TimeScale = _isSlowMotion ? 1f : 0.2f;
            _isSlowMotion = !_isSlowMotion;
        }
    }
}
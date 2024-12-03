using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Audio.AudioSourcesHandlers
{
    public class AudioController : MonoBehaviour
    {
        private float _currentPitch = 1.0f; 
        private const float MinPitch = 0.5f; 
        private const float MaxPitch = 1.0f; 
        private const float SmoothSpeed = 4.0f; 
        
        private ITimeService _timeService;

        [Inject]
        public void Construct(ITimeService timeService)
        {
            _timeService = timeService;
        }

        private void Update()
        {
            float targetPitch = Mathf.Clamp(_timeService.TimeScale, MinPitch, MaxPitch);
            _currentPitch = Mathf.Lerp(_currentPitch, targetPitch, Time.deltaTime * SmoothSpeed);
            SetPlaybackSpeed(_currentPitch);
            
        }
        private void SetPlaybackSpeed(float speed)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("TimeController", speed);
        }
    }
}
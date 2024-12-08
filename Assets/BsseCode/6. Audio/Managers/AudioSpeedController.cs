using BsseCode._2._Services.GlobalServices.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode._6._Audio.Managers
{
    public class AudioSpeedController : MonoBehaviour
    {
        private float _currentPitch = 1.0f; 
        private const float MinPitch = 0.5f; 
        private const float MaxPitch = 1.0f; 
        private const float SmoothSpeed = 4.0f; 
        
        private ITimeGlobalService _timeGlobalService;

        [Inject]
        public void Construct(ITimeGlobalService timeGlobalService)
        {
            _timeGlobalService = timeGlobalService;
        }

        private void Update()
        {
            float targetPitch = Mathf.Clamp(_timeGlobalService.TimeScale, MinPitch, MaxPitch);
            _currentPitch = Mathf.Lerp(_currentPitch, targetPitch, Time.deltaTime * SmoothSpeed);
            SetPlaybackSpeed(_currentPitch);
            
        }
        private void SetPlaybackSpeed(float speed)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("TimeController", speed);
        }
    }
}
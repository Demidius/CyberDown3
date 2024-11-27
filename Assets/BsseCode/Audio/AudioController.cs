

using BsseCode.Services.InputFol;
using BsseCode.Services.TimeProvider;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace BsseCode.Audio
{
    public class AudioController : MonoBehaviour
    {
        private ITimeService _timeService;
        private FMOD.ChannelGroup _masterChannelGroup;

        private float _currentPitch = 1.0f; 
        private const float MinPitch = 0.8f; 
        private const float MaxPitch = 1.0f; 
        private const float SmoothSpeed = 4.0f; 

        [Inject]
        public void Construct(ITimeService timeService)
        {
            _timeService = timeService;
            RuntimeManager.CoreSystem.getMasterChannelGroup(out _masterChannelGroup);
        }
    
        private void Update()
        {
            // Ограничиваем целевой pitch в пределах MinPitch и MaxPitch
            float targetPitch = Mathf.Clamp(_timeService.TimeScale, MinPitch, MaxPitch);

            // Плавное изменение текущего pitch
            _currentPitch = Mathf.Lerp(_currentPitch, targetPitch, Time.deltaTime * SmoothSpeed);

            // Устанавливаем плавный pitch
            SetPlaybackSpeed(_currentPitch);
        }
        
        public void SetPlaybackSpeed(float speed)
        {
                _masterChannelGroup.setPitch(speed);
          
        }
    }
}
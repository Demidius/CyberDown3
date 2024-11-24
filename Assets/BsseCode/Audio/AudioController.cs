

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
        private const float MinPitch = 0.5f; 
        private const float MaxPitch = 2.0f; 
        private const float SmoothSpeed = 2.0f; 

        [Inject]
        public void Construct(ITimeService timeService)
        {
            _timeService = timeService;
        }
        private void Start()
        { 
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
            if (_masterChannelGroup.hasHandle())
            {
                // Устанавливаем pitch на Master Channel Group
                _masterChannelGroup.setPitch(speed);
            }
            else
            {
                Debug.LogWarning("Master ChannelGroup is not valid. Cannot set playback speed.");
            }
        }
    }
}
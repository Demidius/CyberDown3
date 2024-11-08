using System;
using UnityEngine;

namespace BsseCode.Services.TimeProvider
{
    public class TimeService : ITimeService
    {
        private const float TimeFactor = 1f;

        private float _timeScale;

        public event Action <float> ChangeTimeScale;

        public TimeService() =>
            _timeScale = TimeFactor;

        public float TimeScale
        {
            get =>
                _timeScale;
            set
            {
                _timeScale = Mathf.Clamp(value, 0, TimeFactor);
                ChangeTimeScale?.Invoke(value);
            }
        }

        public float DeltaTime =>
            UnityEngine.Time.deltaTime * TimeScale;
    }
}
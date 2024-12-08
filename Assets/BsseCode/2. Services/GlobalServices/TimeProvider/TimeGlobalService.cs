using System;
using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.TimeProvider
{
    public class TimeGlobalService : ITimeGlobalService
    {
        private const float TimeFactor = 1f;

        private float _timeScale;

        public event Action <float> ChangeTimeScale;

        public TimeGlobalService() =>
            _timeScale = TimeFactor;

        public void ResetTimeScale() => _timeScale = TimeFactor;
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
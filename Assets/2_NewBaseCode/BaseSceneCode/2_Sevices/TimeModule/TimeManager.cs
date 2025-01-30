using System;
using UnityEngine;

namespace NewBaseCode.BaseScene.Services.TimeModule
{
    public class TimeManager : MonoBehaviour, ITimeManager
    {
        public event Action ChangedTimeScale;
        public float CurrentTimeScale { get; private set; } 
        public float ModificatedDeltaTime { get; private set; }

        private const float DefaultTimeScale = 1f;

        private void Awake()
        {
            CurrentTimeScale = DefaultTimeScale; 
        }

        private void Update()
        {
            UpdateModifiedDeltaTime();
        }

        public void SetNewTimeScale(float newTimeScale)
        {
            if (newTimeScale < 0)
            {
                Debug.LogWarning("Time scale cannot be negative. Setting to default value.");
                newTimeScale = DefaultTimeScale;
            }
            this.CurrentTimeScale = newTimeScale;
            OnChangedTimeScale();
            UpdateModifiedDeltaTime();
        }

        protected virtual void OnChangedTimeScale()
        {
            ChangedTimeScale?.Invoke();
        }

        private void UpdateModifiedDeltaTime()
        {
            ModificatedDeltaTime = Time.deltaTime * CurrentTimeScale;
        }
    }

    public interface ITimeManager
    {
        event Action ChangedTimeScale;
        float CurrentTimeScale { get; }
        float ModificatedDeltaTime { get; }
        void SetNewTimeScale(float newTimeScale);
    }
}
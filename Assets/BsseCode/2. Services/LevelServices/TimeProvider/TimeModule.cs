using System;
using UnityEngine;

namespace BsseCode._2._Services.LevelServices.TimeProvider
{
    public interface ITimeModule
    {
        public event Action<float> ChangeTimeScaleAction;
        float GetTimeScale();
        float GetTimeDeltaTime();
        void SetNewTimeScale(float newTimeScale);
        void ResetTimeScale();
    }

    public class TimeModule : MonoBehaviour, ITimeModule
    {
        public event Action<float> ChangeTimeScaleAction;

        private const float NeutralTimeScale = 1f;
        private float _currentTimeScale = NeutralTimeScale;
        private float _targetTimeScale = NeutralTimeScale;
        private float _changingSpeed = 1f; // Скорость плавного изменения
        private bool _isChanging = false;

        public float GetTimeScale()
        {
            return _currentTimeScale;
        }

        public float GetTimeDeltaTime()
        {
            return _currentTimeScale;
        }

        public void SetNewTimeScale(float newTimeScale)
        {
            _targetTimeScale = Mathf.Clamp(newTimeScale, 0, 1); // Ограничиваем значение, если нужно
            _isChanging = true;
        }

        public void ResetTimeScale()
        {
            _targetTimeScale = NeutralTimeScale;
            _isChanging = true;
        }

        private void Update()
        {
            if (_isChanging)
            {
                _currentTimeScale = Mathf.Lerp(_currentTimeScale, _targetTimeScale, _changingSpeed * Time.deltaTime);

                // Вызываем событие при каждом изменении
                ChangeTimeScaleAction?.Invoke(_currentTimeScale);

                // Останавливаем изменение, если мы близки к целевому значению
                if (Mathf.Abs(_currentTimeScale - _targetTimeScale) < 0.01f)
                {
                    _currentTimeScale = _targetTimeScale;
                    _isChanging = false;
                    ChangeTimeScaleAction?.Invoke(_currentTimeScale); // Финальный вызов события
                }
            }
        }

        public float ChangingSpeed
        {
            get => _changingSpeed;
            set => _changingSpeed = Mathf.Max(0, value); // Защита от отрицательных значений
        }
    }
}
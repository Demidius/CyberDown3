using BsseCode.Constants;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;
using FMODUnity;

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
            // Подписываемся на событие изменения времени
            _inputService.ToggleTimeEvent += ToggleTimeScale;
        }

        private void Update()
        {
            // Проверяем ввод пользователя
            _inputService.ToggleTimeScaleInput();
        }

        private void ToggleTimeScale()
        {
            // Переключаем Time.timeScale
            _timeService.TimeScale = _isSlowMotion ? 1f : Constants.Const.SlowTimeModificator;
            _isSlowMotion = !_isSlowMotion;
            
        }


        private void OnDestroy()
        {
            // Отписываемся от события
            _inputService.ToggleTimeEvent -= ToggleTimeScale;
        }
    }
}

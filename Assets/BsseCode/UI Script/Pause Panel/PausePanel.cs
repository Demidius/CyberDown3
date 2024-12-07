using System;
using BsseCode.Mechanics;
using BsseCode.Services.InputFol;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode.UI_Script.Pause_Panel
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private CursorToSprite cursorToSprite;

        private IInputService _inputService;
        private ITimeService _timeService;
        private float _temtTimeSpeed;

        [Inject]
        public void Construct(IInputService inputService, ITimeService timeService)
        {
            _timeService = timeService;
            _inputService = inputService;
        }

        private void Start()
        {
            _inputService.PauseEvent += ChangeStatus;
        }

        private void Update()
        {
            _inputService.PauseInput();
        }

        private void ChangeStatus(bool status)
        {
            if (status)
            {
                pausePanel.SetActive(true);
                _temtTimeSpeed = _timeService.TimeScale;
                _timeService.TimeScale = 0;
                cursorToSprite.ReturnCursor();
            }
            else
            {
                pausePanel.SetActive(false);
                _timeService.TimeScale = _temtTimeSpeed;
                _temtTimeSpeed = 1;
                cursorToSprite.SetCorsor();
            }
        }

        private void OnDestroy()
        {
            _inputService.PauseEvent -= ChangeStatus;
        }
    }
}
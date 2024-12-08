using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices;
using UnityEngine;
using Zenject;

namespace BsseCode._4._UI.Pause_Panel
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private CursorToSprite cursorToSprite;

        private IInputGlobalService _inputGlobalService;
        private ITimeGlobalService _timeGlobalService;
        private float _temtTimeSpeed;

        [Inject]
        public void Construct(IInputGlobalService inputGlobalService, ITimeGlobalService timeGlobalService)
        {
            _timeGlobalService = timeGlobalService;
            _inputGlobalService = inputGlobalService;
        }

        private void Start()
        {
            _inputGlobalService.PauseEvent += ChangeStatus;
        }

        private void Update()
        {
            _inputGlobalService.PauseInput();
        }

        private void ChangeStatus(bool status)
        {
            if (status)
            {
                pausePanel.SetActive(true);
                _temtTimeSpeed = _timeGlobalService.TimeScale;
                _timeGlobalService.TimeScale = 0;
                cursorToSprite.ReturnCursor();
            }
            else
            {
                pausePanel.SetActive(false);
                _timeGlobalService.TimeScale = _temtTimeSpeed;
                _temtTimeSpeed = 1;
                cursorToSprite.SetCorsor();
            }
        }

        private void OnDestroy()
        {
            _inputGlobalService.PauseEvent -= ChangeStatus;
        }
    }
}
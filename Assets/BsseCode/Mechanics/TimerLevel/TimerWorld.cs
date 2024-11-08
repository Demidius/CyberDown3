using BsseCode.Services.TimeProvider;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode.Mechanics.TimerLevel

    {


        public class TimerLevel : MonoBehaviour, ITimerLevel
        {
            [SerializeField] private Text timerText;
            
            public string CurrentTimeOnString { get; set; }
            public float CurrentTimerValue { get; set; }
            
            private ITimeService _timeService;
            private bool _isRunning = false;


            [Inject]
            private void Construct(ITimeService timeService)
            {
                _timeService = timeService;
            }

            void Start()
            {
                ResetTimer();
                StartTimer();
                UpdateTimerUI();
            }

            void Update()
            {
                if (_isRunning)
                {
                    CurrentTimerValue += _timeService.DeltaTime;
                    UpdateTimerUI();
                }
            }

            public void StartTimer()
            {
                CurrentTimerValue = 0f;
                _isRunning = true;
            }

            public void StopTimer()
            {
                _isRunning = false;
            }

            public void ResetTimer()
            {
                CurrentTimerValue = 0f;
                UpdateTimerUI();
            }

            private void UpdateTimerUI()
            {
                if (timerText == null) return;

                int minutes = Mathf.FloorToInt(CurrentTimerValue / 60);
                int seconds = Mathf.FloorToInt(CurrentTimerValue % 60);
                int milliseconds = Mathf.FloorToInt((CurrentTimerValue * 1000) % 1000);

                CurrentTimeOnString = $"{minutes:00}:{seconds:00}:{milliseconds:000}";
                timerText.text = CurrentTimeOnString;
            }
        }
    }
   
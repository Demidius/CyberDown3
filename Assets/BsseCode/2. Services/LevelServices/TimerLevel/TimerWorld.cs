using BsseCode._2._Services.GlobalServices.TimeProvider;
using TMPro;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.LevelServices.TimerLevel

    {


        public class TimerLevel : MonoBehaviour, ITimerLevel
        {
            [SerializeField] private TextMeshProUGUI timerText;
            
            public string CurrentTimeOnString { get; set; }
            public float CurrentTimerValue { get; set; }
            
            private ITimeGlobalService _timeGlobalService;
            private bool _isRunning = false;


            [Inject]
            private void Construct(ITimeGlobalService timeGlobalService)
            {
                _timeGlobalService = timeGlobalService;
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
                    CurrentTimerValue += _timeGlobalService.DeltaTime;
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
   
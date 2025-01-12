using System;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.LevelServices.GameResults
{
    public class KillsController : MonoBehaviour
    {
        [Inject] private ResultsManager _resultsManager;

        public int Kills { get; private set; } = 0;
        private float _survivalTime = 0f;
        private bool _isGameActive = true;

        public event Action ChangeKills;

        void Update()
        {
            if (_isGameActive)
            {
                _survivalTime += Time.deltaTime;
            }
        }

        public void OnEnemyKilled()
        {
            Kills++;
            ChangeKills?.Invoke();
        }

        public void EndGame()
        {
            _isGameActive = false;
            GameResultForm resultForm = new GameResultForm(Kills, _survivalTime, _resultsManager.GetNumberOfTry());
            _resultsManager.AddResult(resultForm);
            // Перейти в меню или выполнить другие действия
        }
        
        
        public void ResetKills()
        {
            Kills = 0;             
            ChangeKills?.Invoke(); 
        }
    }
}
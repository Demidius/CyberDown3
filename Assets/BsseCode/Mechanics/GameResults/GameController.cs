using UnityEngine;
using Zenject;

namespace BsseCode.Mechanics.GameResults
{

    public class GameController : MonoBehaviour
    {
        [Inject]
        private ResultsManager _resultsManager;

        private int _kills = 0;
        private float _survivalTime = 0f;
        private bool _isGameActive = true;

        void Update()
        {
            if (_isGameActive)
            {
                _survivalTime += Time.deltaTime;
            }
        }

        public void OnEnemyKilled()
        {
            _kills++;
        }

        public void EndGame()
        {
            _isGameActive = false;
            GameResult result = new GameResult(_kills, _survivalTime);
            _resultsManager.AddResult(result);
            // Перейти в меню или выполнить другие действия
        }
    }

}
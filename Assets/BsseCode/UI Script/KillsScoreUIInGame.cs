using System;
using BsseCode.Mechanics.GameResults;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode.UI_Script
{
    public class KillsScoreUIInGame : MonoBehaviour
    {
        private Text killsScoreText;
        private KillsController _killsController;

        [Inject]
        public void Construct(KillsController killsController)
        {
            _killsController = killsController;
        }
        
        private void Start()
        {
            killsScoreText = GetComponent<Text>();
            UpdateKillsScoreText();
            _killsController.ChangeKills += UpdateKillsScoreText;
        }

        private void UpdateKillsScoreText()
        {
            killsScoreText.text = _killsController.Kills.ToString();
        }

        private void OnDestroy()
        {
            _killsController.ChangeKills -= UpdateKillsScoreText;
        }
    }
}
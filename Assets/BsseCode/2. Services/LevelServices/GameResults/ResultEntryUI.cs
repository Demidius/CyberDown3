using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode._2._Services.LevelServices.GameResults
{
    public class ResultEntryUI : MonoBehaviour
    {
        public TextMeshProUGUI killsText;
        public TextMeshProUGUI survivalTimeText;
        public TextMeshProUGUI numberOfTry;
        
        public void SetResult(GameResult result)
        {
            killsText.text = $"{result.kills}";
            survivalTimeText.text = $"{FormatTime(result.survivalTime)}";
            numberOfTry.text = $"{result.numberOfTry}";
        }

        private string FormatTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60F);
            int seconds = Mathf.FloorToInt(time % 60F);
            return $"{minutes:00}:{seconds:00}";
        }
    }

}
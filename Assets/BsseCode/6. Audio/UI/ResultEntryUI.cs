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
        
        public void SetResult(GameResultForm resultForm)
        {
            killsText.text = $"{resultForm.kills}";
            survivalTimeText.text = $"{FormatTime(resultForm.survivalTime)}";
            numberOfTry.text = $"{resultForm.numberOfTry}";
        }

        private string FormatTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60F);
            int seconds = Mathf.FloorToInt(time % 60F);
            return $"{minutes:00}:{seconds:00}";
        }
    }

}
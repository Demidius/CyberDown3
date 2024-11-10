namespace BsseCode.Mechanics.GameResults
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ResultEntryUI : MonoBehaviour
    {
        public Text killsText;
        public Text survivalTimeText;

        public void SetResult(GameResult result)
        {
            killsText.text = $"{result.kills}";
            survivalTimeText.text = $"{FormatTime(result.survivalTime)}";
        }

        private string FormatTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60F);
            int seconds = Mathf.FloorToInt(time % 60F);
            return $"{minutes:00}:{seconds:00}";
        }
    }

}
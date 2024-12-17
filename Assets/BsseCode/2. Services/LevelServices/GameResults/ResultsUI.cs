using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.LevelServices.GameResults
{

    public class ResultsUI : MonoBehaviour
    {
        [Inject] private ResultsManager _resultsManager;

        public Transform contentParent; // Родительский объект для контента (например, Vertical Layout Group)
        public GameObject resultEntryPrefab; // Префаб для одной записи результата

        void Start()
        {
            DisplayResults();
        }

        public void DisplayResults()
        {
            List<GameResult> results = _resultsManager.Results;
            Debug.Log(results.Count);
            
            float yOffset = 0f; // Начальное смещение по Y
            float spacing = 50f; // Отступ между элементами

            for (int i = 0; i < Mathf.Min(results.Count, 10); i++) // Ограничиваем до 10 результатов
            {
                GameObject entry = Instantiate(resultEntryPrefab, contentParent);
                entry.transform.localPosition = new Vector3(0, yOffset, 0); // Смещение элемента
                yOffset -= spacing; // Уменьшаем yOffset для следующего элемента

                ResultEntryUI entryUI = entry.GetComponent<ResultEntryUI>();
                entryUI.SetResult(results[i]);
            }
        }
    }
}
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;
    
namespace BsseCode.Mechanics.GameResults
{

    public class ResultsUI : MonoBehaviour
    {
        [Inject]
        private ResultsManager _resultsManager;

        public Transform contentParent; // Родительский объект для контента (например, Vertical Layout Group)
        public GameObject resultEntryPrefab; // Префаб для одной записи результата

        void Start()
        {
            DisplayResults();
        }

        void DisplayResults()
        {
            List<GameResult> results = _resultsManager.Results;
            Debug.Log(results.Count);

            foreach (GameResult result in results)
            {
                GameObject entry = Instantiate(resultEntryPrefab, contentParent);
                ResultEntryUI entryUI = entry.GetComponent<ResultEntryUI>();
                entryUI.SetResult(result);
                Debug.Log(result);
            }
        }
    }

}
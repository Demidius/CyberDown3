using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.LevelServices.GameResults
{
    public class ResultsUI : MonoBehaviour
    {
        [Inject] private ResultsManager _resultsManager;

        public Transform contentParent;
        public GameObject resultEntryPrefab;

        private List<GameObject> _createdEntries = new List<GameObject>();

        void Start()
        {
            DisplayResults();
        }

        public void DisplayResults()
        {
            ClearAllResults();
            List<GameResult> results = _resultsManager.Results;
            Debug.Log(results.Count);

            float yOffset = 0f;
            float spacing = 50f;

            for (int i = 0; i < Mathf.Min(results.Count, 10); i++)
            {
                GameObject entry = Instantiate(resultEntryPrefab, contentParent);
                _createdEntries.Add(entry); // Добавляем созданный объект в список
                
                entry.transform.localPosition = new Vector3(0, yOffset, 0);
                yOffset -= spacing;

                ResultEntryUI entryUI = entry.GetComponent<ResultEntryUI>();
                entryUI.SetResult(results[i]);
            }
        }

        public void ClearAllResults()
        {
            foreach (var entry in _createdEntries)
            {
                if (entry != null)
                {
                    Destroy(entry);
                }
            }
            _createdEntries.Clear();
        }
    }
}
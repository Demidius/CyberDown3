using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BsseCode._2._Services.LevelServices.GameResults
{
    public class ResultsManager : MonoBehaviour
    {
        private const string SaveFileName = "results.json";
        private List<GameResult> results = new List<GameResult>();

        public List<GameResult> Results => results;

        private void Awake()
        {
            LoadResults();
        }

        public void AddResult(GameResult result)
        {
            results.Add(result);
            SortResults();
            SaveResults();
        }

        private void SortResults()
        {
            results.Sort((a, b) => b.kills.CompareTo(a.kills));
        }

        private void SaveResults()
        {
            string json = JsonUtility.ToJson(new GameResultsWrapper(results), true);
            File.WriteAllText(GetSaveFilePath(), json);
        }

        private void LoadResults()
        {
            string path = GetSaveFilePath();
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                GameResultsWrapper wrapper = JsonUtility.FromJson<GameResultsWrapper>(json);
                results = wrapper.results;
            }
        }

        private string GetSaveFilePath()
        {
            return Path.Combine(Application.persistentDataPath, SaveFileName);
        }
    }

   

}
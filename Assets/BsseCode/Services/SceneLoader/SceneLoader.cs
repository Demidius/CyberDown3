using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BsseCode.Services.SceneLoader
{
    public class SceneLoader : MonoBehaviour
    {
        // Метод для асинхронной загрузки сцены
        public void LoadSceneAsync(string sceneName)
        {
            // Начинаем асинхронную загрузку сцены
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            // Загружаем сцену асинхронно
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        
            // Ожидаем завершения загрузки
            while (!asyncLoad.isDone)
            {
                // Можно использовать asyncLoad.progress для отображения загрузки, например, на экране
                Debug.Log($"Загрузка сцены {sceneName}: {asyncLoad.progress * 100}%");
                yield return null;
            }

            OnSceneLoaded();
        }

        // Метод, вызываемый при завершении загрузки
        private void OnSceneLoaded()
        {
            Debug.Log("Сцена загружена успешно!");
            // Можно выполнить действия после загрузки сцены
        }
    }
}
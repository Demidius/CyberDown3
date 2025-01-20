using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._3._UI._4.TextBechaviors
{
    public class SequentialTextTyper : MonoBehaviour
    {
        public List<TextMeshProUGUI> textMeshProObjects; // Список объектов с TextMeshPro
        private const float DelayBetweenLetters = 0.05f; // Задержка между буквами
        private const float DelayBetweenTexts = 0.05f; // Задержка между текстами

        private void OnEnable()
        {
            StartCoroutine(TypeTextsSequentially());
        }

        private IEnumerator TypeTextsSequentially()
        {
            foreach (var textMeshPro in textMeshProObjects)
            {
                if (textMeshPro == null) continue; // Пропускаем null-объекты
                string fullText = textMeshPro.text; // Сохраняем полный текст
                textMeshPro.text = ""; // Очищаем текущий текст

                // Выводим текст по буквам
                foreach (char letter in fullText)
                {
                    textMeshPro.text += letter;
                    yield return new WaitForSeconds(DelayBetweenLetters);
                }

                // Делаем паузу перед следующим текстом
                yield return new WaitForSeconds(DelayBetweenTexts);
            }
        }
    }


}
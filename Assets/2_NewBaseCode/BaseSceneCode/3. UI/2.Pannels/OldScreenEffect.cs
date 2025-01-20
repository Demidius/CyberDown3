using UnityEngine;
using UnityEngine.UI;

namespace _2_NewBaseCode.BaseSceneCode._3._UI._2.Pannels
{
    public class OldScreenEffect : MonoBehaviour
    {
        [SerializeField] private Image panelImage; // Ссылка на Image, к которому применяем эффект
        [SerializeField] private float colorChangeSpeed = 0.2f; // Скорость изменения цвета

        private Color originalColor;

        void Start()
        {
            if (panelImage != null)
            {
                // Сохраняем оригинальный цвет
                originalColor = panelImage.color;
            }
            else
            {
                Debug.LogWarning("panelImage не задан.");
            }
        }

        void Update()
        {
            if (panelImage != null)
            {
                // Рандомное изменение RGB-каналов с учётом скорости
                float r = originalColor.r + Random.Range(-colorChangeSpeed, colorChangeSpeed);
                float g = originalColor.g + Random.Range(-colorChangeSpeed, colorChangeSpeed);
                float b = originalColor.b + Random.Range(-colorChangeSpeed, colorChangeSpeed);

                // Ограничиваем значения цвета от 0 до 1
                r = Mathf.Clamp(min:0.10f, max:0.12f, value:r);
                g = Mathf.Clamp(min:0.49f, max:0.51f, value:g);
                b = Mathf.Clamp(min:0.20f, max:0.22f, value:b);

                // Применяем изменённый цвет
                panelImage.color = new Color(r, g, b, originalColor.a);
            }
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace NewBaseCode._3._UI._2.Pannels
{
    public class OldScreenEffect : MonoBehaviour
    {
        public Image panelImage; // Ссылка на Image, к которому применяем эффект
        private float colorChangeSpeed = 1f; // Скорость изменения цвета

        private Color originalColor;

        void Start()
        {
            if (panelImage != null)
            {
                originalColor = panelImage.color;
            }
        }

        void Update()
        {
            if (panelImage != null)
            {
                // Рандомное изменение RGB-каналов
                float r = originalColor.r + Random.Range(-0.02f, 0.02f);
                float g = originalColor.g + Random.Range(-0.02f, 0.02f);
                float b = originalColor.b + Random.Range(-0.02f, 0.02f);

                // Ограничиваем значения цвета от 0 до 1
                r = Mathf.Clamp01(r);
                g = Mathf.Clamp01(g);
                b = Mathf.Clamp01(b);

                // Применяем изменённый цвет
                panelImage.color = new Color(r, g, b, originalColor.a);
            }
        }
    }
}
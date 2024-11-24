using UnityEditor;
using UnityEngine;

namespace BsseCode.Services.ColorHeaders
{
    [CustomPropertyDrawer(typeof(ColoredHeaderAttribute))]
    public class ColoredHeaderDrawer : DecoratorDrawer
    {
        public override float GetHeight()
        {
            // Добавляем автоматический отступ перед ColoredHeader
            ColoredHeaderAttribute header = (ColoredHeaderAttribute)attribute;
            return EditorGUIUtility.singleLineHeight + 15; 
        }
        
        public override void OnGUI(Rect position)
        {
            ColoredHeaderAttribute header = (ColoredHeaderAttribute)attribute;

            // Добавляем вертикальный отступ
            position.y += 5;

            // Настройка стиля
            GUIStyle style = new GUIStyle(EditorStyles.boldLabel)
            {
                fontSize = header.FontSize,
                normal = { textColor = header.GetColor() }
            };

            // Отображение заголовка
            EditorGUI.LabelField(position, header.Header, style);
        }

   
    }
}

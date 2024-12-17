using UnityEngine;

namespace BsseCode._4._UI.Cursor
{
    public class CursorToSprite : MonoBehaviour
    {
        [SerializeField] private Texture2D cursorSprite; // Текстура для курсора
        [SerializeField] private Vector2 hotSpot = Vector2.zero; // Точка привязки (по умолчанию верхний левый угол)

        private void OnEnable()
        {
            SetCorsor();

        }

        public void SetCorsor()
        {
            UnityEngine.Cursor.SetCursor(cursorSprite, hotSpot, CursorMode.Auto);
        }

        public void OnDisable()
        {
            // Вернуть стандартный курсор, если объект деактивирован
            UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
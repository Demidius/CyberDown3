using UnityEngine;

namespace BsseCode._2._Services.LevelServices
{
    public class CursorToSprite : MonoBehaviour
    {
        [SerializeField] private Texture2D cursorSprite; // Текстура для курсора
        [SerializeField] private Vector2 hotSpot = Vector2.zero; // Точка привязки (по умолчанию верхний левый угол)

        private void Start()
        {
            SetCorsor();

        }

        public void SetCorsor()
        {
            Cursor.SetCursor(cursorSprite, hotSpot, CursorMode.Auto);
        }

        public void ReturnCursor()
        {
            // Вернуть стандартный курсор, если объект деактивирован
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
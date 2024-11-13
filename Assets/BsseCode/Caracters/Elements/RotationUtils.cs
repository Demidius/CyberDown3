using UnityEngine;

namespace BsseCode.Caracters.Elements
{
    public static class RotationUtils
    {
        // Универсальный метод для получения направления к мыши от любой позиции
        public static Vector3 GetDirectionToMouse(Vector3 startPosition, Camera camera)
        {
            Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = startPosition.z;  // Сохраняем ту же глубину (ось Z) для расчета 2D направления
            return (mousePosition - startPosition).normalized;
        }

        public static void RotateTowardsDirection(Transform targetTransform, Vector3 direction)
        {
            targetTransform.up = direction.normalized;
        }
    }
}
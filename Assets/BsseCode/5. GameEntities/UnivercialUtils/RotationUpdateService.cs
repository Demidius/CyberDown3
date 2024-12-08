using UnityEngine;

namespace BsseCode._5._GameEntities.UnivercialUtils
{
    public static class RotationUpdateService
    {
        public static Vector3 GetDirectionToMouse(Vector3 startPosition, Camera camera)
        {
            Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = startPosition.z; 
            return (mousePosition - startPosition).normalized;
        }

        public static void RotateTowardsDirection(Transform targetTransform, Vector3 direction)
        {
            targetTransform.up = direction.normalized;
        }
    }
}
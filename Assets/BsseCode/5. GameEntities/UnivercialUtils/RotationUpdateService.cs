using UnityEngine;

namespace BsseCode._5._GameEntities.UnivercialUtils
{
    public static class RotationUpdateService
    {
        
      

        public static void RotateTowardsDirection(Transform targetTransform, Vector3 direction)
        {
            targetTransform.up = direction.normalized;
        }
    }
}
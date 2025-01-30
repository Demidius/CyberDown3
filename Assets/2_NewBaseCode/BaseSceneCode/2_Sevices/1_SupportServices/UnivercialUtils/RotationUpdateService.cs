using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.UnivercialUtils
{
    public class RotationUpdateService
    {
        public void RotateTowardsDirection(Transform targetTransform, Vector3 direction)
        {
            targetTransform.up = direction.normalized;
        }
    }
  
}
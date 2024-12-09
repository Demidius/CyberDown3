using BsseCode._2._Services.GlobalServices.TimeProvider;
using UnityEngine;

namespace BsseCode._5._GameEntities.UnivercialUtils
{
    public class PositionUpdateService
    {
        private readonly ITimeGlobalService _timeGlobalService;
        public PositionUpdateService(ITimeGlobalService timeGlobalService)
        {
            _timeGlobalService = timeGlobalService;
        }
       public Vector3 Move(Vector2 moveDirection, float movementSpeed, Vector3 objPosition)
        {
            Vector2 normalizedDirection = moveDirection.normalized;
            Vector3 newpPosition = new Vector3(normalizedDirection.x, normalizedDirection.y, 0) * (movementSpeed * _timeGlobalService.DeltaTime);
            objPosition += newpPosition;
            return objPosition;
        }
    }
}

   
  

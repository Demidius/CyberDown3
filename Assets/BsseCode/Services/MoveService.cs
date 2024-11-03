using BsseCode.Services.TimeProvider;
using UnityEngine;

namespace BsseCode.Services
{
    public class MoveService
    {
        private readonly ITimeService _timeService;

        public MoveService(ITimeService timeService)
        {
            _timeService = timeService;
        }
        
       public Vector3 Move(Vector2 moveDirection, float movementSpeed, Vector3 objPosition)
        {
            Vector3 newpPosition = new Vector3(moveDirection.x, moveDirection.y, 0) * (movementSpeed * _timeService.DeltaTime);
            objPosition += newpPosition;
            return objPosition;
        }
    }
}
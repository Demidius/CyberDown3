using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices.TimeProvider;
using UnityEngine;

namespace BsseCode._5._GameEntities.UnivercialUtils
{
    public interface IPositionUpdateService
    {
        Vector3 Move(Vector2 moveDirection, float movementSpeed, Vector3 objPosition);
    }

    public class PositionUpdateService : IPositionUpdateService
    {
        private readonly ITimeModule _timeModule;
        public PositionUpdateService(ITimeModule timeModule)
        {
            _timeModule = timeModule;
        }
       public Vector3 Move(Vector2 moveDirection, float movementSpeed, Vector3 objPosition)
        {
            Vector2 normalizedDirection = moveDirection.normalized;
            Vector3 newpPosition = new Vector3(normalizedDirection.x, normalizedDirection.y, 0) * (movementSpeed * _timeModule.GetTimeDeltaTime());
            objPosition += newpPosition;
            return objPosition;
        }
    }
}

   
  

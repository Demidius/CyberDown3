using BsseCode._2._Services.LevelServices.TimeProvider;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.UnivercialUtils
{
    public interface IPositionUpdateService
    {
        Vector3 Move(Vector2 moveDirection, float movementSpeed, Vector3 objPosition);
    }

    public class PositionUpdateService : IPositionUpdateService
    {
        // private readonly ITimeModule _timeModule;
        // public PositionUpdateService(ITimeModule timeModule)
        // {
        //     _timeModule = timeModule;
        // }
        
       public Vector3 Move(Vector2 moveDirection, float movementSpeed, Vector3 objPosition)
        {
            Vector2 normalizedDirection = moveDirection.normalized;
            Vector3 newpPosition = new Vector3(normalizedDirection.x, normalizedDirection.y, 0) * (movementSpeed ); //* _timeModule.GetTimeDeltaTime()
            objPosition += newpPosition;
            return objPosition;
        }
    }
}

   
  

using UnityEngine;

namespace BsseCode.Services
{
    public class MoveService
    {
       public Vector3 Move(Vector2 moveDirection, float movementSpeed, Vector3 objPosition)
        {
            Vector3 newpPosition = new Vector3(moveDirection.x, moveDirection.y, 0) * (movementSpeed * Time.deltaTime);
            objPosition += newpPosition;
            return objPosition;
        }
    }
}
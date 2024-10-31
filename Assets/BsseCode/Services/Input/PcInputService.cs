using UnityEngine;

namespace BsseCode.Services.Input
{
    public class PcInputService : IInputService
    {
        public Vector2 GetMovementInput()
        {
            // Получаем ввод с клавиш WASD или стрелок
            float horizontal = UnityEngine.Input.GetAxis("Horizontal");
            float vertical = UnityEngine.Input.GetAxis("Vertical");
            return new Vector2(horizontal, vertical);
        }
    }
}
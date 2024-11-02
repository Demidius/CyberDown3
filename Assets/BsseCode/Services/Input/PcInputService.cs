using System;
using BsseCode.Constants;
using UnityEngine;

namespace BsseCode.Services.Input
{
    public class PcInputService : IInputService
    {
        public event Action ShootType1;
        
        public Vector2 GetMovementInput()
        {
            // Получаем ввод с клавиш WASD или стрелок
            float horizontal = UnityEngine.Input.GetAxis(ConstansBase.Horizontal);
            float vertical = UnityEngine.Input.GetAxis(ConstansBase.Vertical);
            return new Vector2(horizontal, vertical);
        }

        public void Shoot()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Piu!");
                ShootType1?.Invoke();
            }
        }
        
    }
}
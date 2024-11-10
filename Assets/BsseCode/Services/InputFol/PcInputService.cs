using System;
using BsseCode.Constants;
using UnityEngine;

namespace BsseCode.Services.InputFol
{
    public class PcInputService : IInputService
    {
        public event Action ShootType1;
        public event Action ToggleTimeEvent;
        
        public Vector2 GetMovementInput()
        {
            // Получаем ввод с клавиш WASD или стрелок
            float horizontal = UnityEngine.Input.GetAxis(Constants.Const.Horizontal);
            float vertical = UnityEngine.Input.GetAxis(Constants.Const.Vertical);
            return new Vector2(horizontal, vertical);
        }

        public void Shoot()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
            {
                ShootType1?.Invoke();
            }
        }
        
        public void ToggleTimeScaleInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                ToggleTimeEvent?.Invoke();
            }
        }
        
    }
}
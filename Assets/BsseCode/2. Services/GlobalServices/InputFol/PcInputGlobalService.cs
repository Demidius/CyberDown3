using System;
using BsseCode._3._SupportCode.Constants;
using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.InputFol
{
    public class PcInputGlobalService : IInputGlobalService
    {
        private bool isPause = false;
        public event Action ShootType1;
        public event Action ToggleTimeEvent;
        public event Action<bool> PauseEvent;
        
        public Vector2 GetMovementInput()
        {
            // Получаем ввод с клавиш WASD или стрелок
            float horizontal = UnityEngine.Input.GetAxis(Const.Horizontal);
            float vertical = UnityEngine.Input.GetAxis(Const.Vertical);
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

        public void PauseInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = !isPause;
                PauseEvent?.Invoke(isPause);
            }
        }
    }
}
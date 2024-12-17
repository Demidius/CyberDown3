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

        private Vector2 _lastLegsPosition;
        private Vector2 _lastBodyPosition;
        public bool OnGameplayState { get; set; } = false;


        public Vector3 GetDirectionToMouse(Vector3 startPosition, Camera camera)
        {
            if (OnGameplayState)
            {
                Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = startPosition.z;
                _lastBodyPosition = (mousePosition - startPosition).normalized;
            }
            return _lastBodyPosition;
        }

        public Vector2 GetMovementInput()
        {
            if (OnGameplayState)
            {
                float horizontal = UnityEngine.Input.GetAxis(Const.Horizontal);
                float vertical = UnityEngine.Input.GetAxis(Const.Vertical);
                _lastLegsPosition = new Vector2(horizontal, vertical);
            }
            return _lastLegsPosition;
        }

        public void Shoot()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0) && OnGameplayState)
            {
                ShootType1?.Invoke();
            }
        }

        public void ToggleTimeScaleInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && OnGameplayState)
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
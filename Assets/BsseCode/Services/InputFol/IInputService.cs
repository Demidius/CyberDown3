using System;
using UnityEngine;

namespace BsseCode.Services.InputFol
{
    public interface IInputService : IService
    {
        public event  Action ShootType1;
        public event Action<bool> PauseEvent;
        public event Action ToggleTimeEvent;
        
        
        Vector2 GetMovementInput(); // Метод для получения ввода на передвижение

        public void Shoot();
        public void ToggleTimeScaleInput();
        public void PauseInput();
    }
}
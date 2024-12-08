using System;
using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.InputFol
{
    public interface IInputGlobalService : IGlobalService
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
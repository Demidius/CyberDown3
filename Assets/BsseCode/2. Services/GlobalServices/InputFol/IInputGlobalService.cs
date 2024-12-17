using System;
using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.InputFol
{
    public interface IInputGlobalService : IGlobalService
    {
        public event  Action ShootType1;
        public event Action<bool> PauseEvent;
        public event Action ToggleTimeEvent;

        public bool OnGameplayState { get; set; }
        
        Vector2 GetMovementInput(); // Метод для получения ввода на передвижение

        public Vector3 GetDirectionToMouse(Vector3 startPosition, Camera camera);
        public void Shoot();
        public void ToggleTimeScaleInput();
        public void PauseInput();
    }
}
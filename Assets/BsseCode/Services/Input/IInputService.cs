using System;
using UnityEngine;


namespace BsseCode.Services.Input
{
    public interface IInputService : IService
    {
        public event  Action ShootType1;
        Vector2 GetMovementInput(); // Метод для получения ввода на передвижение

        public void Shoot();
    }
}
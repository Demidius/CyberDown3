using System;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol
{
    public interface IInputService
    {
        void Update();
        public event Action SpaseKeyDown;
        public event Action EscapeKeyDown;
        Vector2 MousePosition { get; }
        Vector2 GetMovementDirectionInput(); 
    }
}



    //     public event  Action ShootType1;
    //     public event Action<bool> PauseEvent;
    //     public event Action ToggleTimeEvent;
        // public bool OnGameplayState { get; set; }

        // public void Shoot();
        // public void ToggleTimeScaleInput();
        // public void PauseInput();
        // Vector3 GetDirectionToMouse(Vector3 startPosition);

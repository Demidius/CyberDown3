using System;
using _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices._1_Const;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol
{
    public class InputController : MonoBehaviour, IInputController
    {
        public event Action Shoot;
        public Vector2 PlayerMoveDirection { get; private set; }
        public Vector2 PlayerSmoothMoveDirection { get; private set; }
        public Vector2 MousePosition { get; private set; }
        
        private InputControls _inputControls;

        void Awake()
        {
            _inputControls = new InputControls();
            _inputControls.Enable();
            // GameplayOnDisable();
            // UIOnDisable();
        }

        private void OnEnable()
        {
            _inputControls.Gameplay.Shoot.performed += ShootEvent;
        }

        private void OnDisable()
        {
            _inputControls.Gameplay.Shoot.performed -= ShootEvent;
        }

        private void ShootEvent(InputAction.CallbackContext context)
        {
            Shoot?.Invoke();
        }

        public void GameplayOnEnable()
        {
            // _inputControls.Gameplay.Enable();
        }
        public void UIOnEnable()
        {
            // _inputControls.UI.Enable();
        }
        public void GameplayOnDisable()
        {
            // _inputControls.Gameplay.Disable();
        }
        public void UIOnDisable()
        {
            // _inputControls.UI.Disable();
        }
        
        private void Update()
        {
            PlayerMoveDirection = MoveInput();
            PlayerSmoothMoveDirection = GetSmoothedVector(PlayerMoveDirection);
            MousePosition = MouseDirectionInput();
        }

        private Vector2 GetSmoothedVector(Vector2 value)
        {
            return Vector2.Lerp(PlayerSmoothMoveDirection, value, Time.deltaTime / Const1.SmoothTime);
        }

        private Vector2 MoveInput()
        {
            return _inputControls.Gameplay.Move.ReadValue<Vector2>();
        }

        private Vector2 MouseDirectionInput()
        {
            Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Vector2 positionTemp = _inputControls.Gameplay.MousePosition.ReadValue<Vector2>();
            return MousePosition = positionTemp - screenCenter;
        }

        
    }

    public interface IInputController
    {
        event Action Shoot;
        Vector2 PlayerMoveDirection { get; }
        Vector2 PlayerSmoothMoveDirection { get; }
        Vector2 MousePosition { get; }
        void GameplayOnEnable();
        void UIOnEnable();
        void GameplayOnDisable();
        void UIOnDisable();
    }
}
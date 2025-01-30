using System;
using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices._1._Const;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol
{
    public class InputServiceGameState : MonoBehaviour, IInputService
    {
        private Vector2 _moveDirection;
        public Vector2 MousePosition { get; private set; }
        public event Action SpaseKeyDown;
        public event Action EscapeKeyDown;

        private ICameraHandler _cameraHandler;
        private IInputSwitcher _inputSwitcher;

        [Inject]
        void Construct
        (
            ICameraHandler cameraHandler,
            IInputSwitcher inputSwitcher
        )
        {
            _inputSwitcher = inputSwitcher;
            _cameraHandler = cameraHandler;
        }

        public void Update()
        {
            UpdateMousePosition();
            GetMovementDirectionInput();
            SpaseInput();
            EscapeInput();
        }

        void UpdateMousePosition()
        {
            if (_inputSwitcher.OnGameInputState)
            {
                MousePosition = _cameraHandler.GetCamera().ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(MousePosition);
            }
        }

        public Vector2 GetMovementDirectionInput()
        {
            if (_inputSwitcher.OnGameInputState)
            {
                float horizontal = Input.GetAxis(Const1.Horizontal);
                float vertical = Input.GetAxis(Const1.Vertical);
                _moveDirection = new Vector2(horizontal, vertical);
            }

            return _moveDirection;
        }

        private void SpaseInput()
        {
            if (_inputSwitcher.OnGameInputState)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SpaseKeyDown?.Invoke();
                }
            }
        }

        private void EscapeInput()
        {
            if (_inputSwitcher.OnGameInputState || _inputSwitcher.OnPauseInputState)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    EscapeKeyDown?.Invoke();
                }
            }
        }
    }
}
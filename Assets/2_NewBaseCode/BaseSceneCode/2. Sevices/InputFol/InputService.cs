using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices._1._Const;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol
{
    public class InputService : MonoBehaviour, IInputService
    {
        public Vector2 MousePosition { get; private set; }
        
        private ICameraHandler _cameraHandler;

        [Inject]
        void Construct(ICameraHandler cameraHandler)
        {
            _cameraHandler = cameraHandler;
        }
        private void Update()
        {
            UpdateMousePosition();
            GetMovementDirectionInput();
        }

        void UpdateMousePosition()
        {
            MousePosition = _cameraHandler.GetCamera().ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(MousePosition);
        }
        
        public Vector2 GetMovementDirectionInput()
        {
            float horizontal = Input.GetAxis(Const1.Horizontal);
            float vertical = Input.GetAxis(Const1.Vertical);
            var moveDirection = new Vector2(horizontal, vertical);
           
            return moveDirection;
        }
    }
}
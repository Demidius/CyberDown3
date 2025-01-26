// using System;
// using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices._1._Const;
// using _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler;
// using UnityEngine;
// using UnityEngine.PlayerLoop;
// using Zenject;
//
// namespace _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol
// {
//     public class PcInputGlobalService : MonoBehaviour, IInputGlobalService
//     {
//         private bool isPause;
//         public event Action ShootType1;
//         public event Action ToggleTimeEvent;
//         public event Action<bool> PauseEvent;
//
//         private Vector2 _newLegsPosition;
//         private Vector2 _lastBodyPosition;
//         public Vector2 MousePosition { get; private set; }
//
//         // public bool OnGameplayState { get; set; } = true;
//         private ICameraHandler _cameraHandler;
//
//         [Inject]
//         void Construct(ICameraHandler cameraHandler)
//         {
//             _cameraHandler = cameraHandler;
//         }
//
//         private void Update()
//         {
//             UpdateMousePosition();
//         }
//
//         void UpdateMousePosition()
//         {
//             MousePosition = _cameraHandler.GetCamera().ScreenToWorldPoint(Input.mousePosition);
//             Debug.Log(MousePosition);
//         }
//         
//         public Vector3 GetDirectionToMouse(Vector3 startPosition)
//         {
//             // if (OnGameplayState)
//             // {
//                 _lastBodyPosition = (MousePosition - startPosition).normalized;
//             // }
//
//             return _lastBodyPosition;
//         }
//
//         public Vector2 GetMovementDirectionInput()
//         {
//             // if (OnGameplayState)
//             // {
//                 float horizontal = Input.GetAxis(Const1.Horizontal);
//                 float vertical = Input.GetAxis(Const1.Vertical);
//                 _newLegsPosition = new Vector2(horizontal, vertical);
//             // }
//
//             return _newLegsPosition;
//         }
//
//         // Этот метод будет вызываться Zenject на каждом кадре
//         public void Tick()
//         {
//             // if (OnGameplayState)
//             // {
//                 Shoot();
//                 ToggleTimeScaleInput();
//                 PauseInput();
//             // }
//         }
//
//         private void Shoot()
//         {
//             if (Input.GetKeyDown(KeyCode.Mouse0))
//             {
//                 ShootType1?.Invoke();
//             }
//         }
//
//         private void ToggleTimeScaleInput()
//         {
//             if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 ToggleTimeEvent?.Invoke();
//             }
//         }
//
//         private void PauseInput()
//         {
//             if (Input.GetKeyDown(KeyCode.Escape))
//             {
//                 isPause = !isPause;
//                 PauseEvent?.Invoke(isPause);
//             }
//         }
//     }
// }

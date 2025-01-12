// using BsseCode._2._Services.GlobalServices.InputFol;
// using BsseCode._2._Services.LevelServices.BulletCounter;
// using BsseCode._3._SupportCode.Constants;
// using UnityEngine;
// using Zenject;
//
// namespace BsseCode._2._Services.GlobalServices.TimeProvider
// {
//     public class TimeController : MonoBehaviour
//     {
//         public bool IsSlowMotionActive { get; private set; }
//         private IInputGlobalService _inputGlobalService;
//         private IEnergyCounter _energyCounter;
//         private ITimeModule _timeModule;
//
//         [Inject]
//         public void Construct(IInputGlobalService inputGlobalService, IEnergyCounter energyCounter, ITimeModule timeModule)
//         {
//             _timeModule = timeModule;
//             _energyCounter = energyCounter;
//             _inputGlobalService = inputGlobalService;
//         }
//
//         private void Start()
//         {
//             ResetIsSlowMotion();
//             _inputGlobalService.ToggleTimeEvent += ToggleTimeScale;
//             _energyCounter.OnEnergyBarEmpty += ExitFromSlowMotion;
//         }
//
//         public void ResetIsSlowMotion()
//         {
//             IsSlowMotionActive = false;
//         }
//
//        
//         private void ToggleTimeScale()
//         {
//             _timeModule.SetNewTimeScale(IsSlowMotionActive ? Const.NormalTimeModificator : Const.SlowTimeModificator);
//             if (Mathf.Approximately(_timeModule.GetTimeScale(), Const.NormalTimeModificator))
//             {
//                 IsSlowMotionActive = false;
//             }
//             else
//             {
//                 IsSlowMotionActive = true;
//             } 
//         }
//
//         private void ExitFromSlowMotion()
//         {
//             _timeModule.ResetTimeScale();
//             IsSlowMotionActive = false;
//         }
//
//
//         private void OnDestroy()
//         {
//             // Отписываемся от события
//             _inputGlobalService.ToggleTimeEvent -= ToggleTimeScale;
//         }
//     }
// }
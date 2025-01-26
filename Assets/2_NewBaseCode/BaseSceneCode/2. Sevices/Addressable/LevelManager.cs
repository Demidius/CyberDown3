using _2_NewBaseCode.BaseSceneCode._1._GameMachine;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices.Addressable
{
    public class LevelManager : MonoBehaviour
    {
        private IGameMachineModule _gameMachineModule;
        private ICameraHandler _gameMachineCameraHandler;
      

        [Inject]
        void Construct(
            IGameMachineModule gameMachineModule,
            ICameraHandler gameMachineCameraHandler
         
            )
        {
           
            _gameMachineCameraHandler = gameMachineCameraHandler;
            _gameMachineModule = gameMachineModule;
        }
        public void Initialize()
        {
            Debug.Log("Level initialized");
           
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.GameState);
            // _gameMachineCameraHandler.MoveTo(Vector2.zero);
        }
    }
}
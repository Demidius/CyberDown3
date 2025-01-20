using _2_NewBaseCode.BaseSceneCode._1._GameMachine;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.Spawners.PlayerHandlerFl;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices.Addressable
{
    public class LevelManager : MonoBehaviour
    {
        private IGameMachineModule _gameMachineModule;
        private ICameraHandler _gameMachineCameraHandler;
        private IPlayerHandler _playerHandler;

        [Inject]
        void Construct(
            IGameMachineModule gameMachineModule,
            ICameraHandler gameMachineCameraHandler,
            IPlayerHandler playerHandler
            )
        {
            _playerHandler = playerHandler;
            _gameMachineCameraHandler = gameMachineCameraHandler;
            _gameMachineModule = gameMachineModule;
        }
        public void Initialize()
        {
            Debug.Log("Level initialized");
           
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.GameState);
            _playerHandler.CreatePlayer();
            // _gameMachineCameraHandler.MoveTo(Vector2.zero);
        }
    }
}
using _2_NewBaseCode.BaseSceneCode._1_GameMachine;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.CameraHandler;
using _2_NewBaseCode.Level1.Entites._1_Player._1_PlayerHandler;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1._1_Level1Controllers
{
    public class LevelManager : MonoBehaviour
    {
        private IGameMachineModule _gameMachineModule;
        private ICameraHandler _cameraHandler;
        private IPlayerHandler _playerHandler;
        private ISlowMotionController _slowMotionController;

        [Inject]
        void Construct(
            IGameMachineModule gameMachineModule,
            ICameraHandler cameraHandler,
            IPlayerHandler playerHandler,
            ISlowMotionController slowMotionController
            )
        {
            _slowMotionController = slowMotionController;
            _playerHandler = playerHandler;
            _cameraHandler = cameraHandler;
            _gameMachineModule = gameMachineModule;
        }
        public void InitializeScene()
        {
            Debug.Log("Level initialized");
           
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.GameState);
            _playerHandler.CreatePlayer();
            _cameraHandler.GetVirtualCamera().Follow = _playerHandler.GetPlayerPosition();
            _slowMotionController.SetBaseLevelTimeScale();
        }
    }
}
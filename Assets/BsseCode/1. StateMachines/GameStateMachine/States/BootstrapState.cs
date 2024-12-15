using BsseCode._2._Services.GlobalServices.Addressable;
using BsseCode._3._SupportCode.Constants;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class BootstrapState : IGameState
    {
        private GameMachineStarter _gameMachineStarter;
        private IAddressableLoader _addressableLoader;

        public BootstrapState(GameMachineStarter gameMachineStarter, IAddressableLoader addressableLoader)
        {
            _addressableLoader = addressableLoader;
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            Debug.Log("Bootstrap: Инициализация игры");
            // _gameStateMachine.SetState(new LoadLevelState(_gameStateMachine, Const.Menu));
        }
        
        public void StartGame()
        {
            _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.LoadingState);
            _addressableLoader.LoadLevelByIndex(0);
        }
        

        public void Exit()
        {
            // Очистка данных, если необходимо
        }
    }
}
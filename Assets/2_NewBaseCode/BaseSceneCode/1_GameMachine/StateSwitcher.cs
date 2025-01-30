using System;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.Addressable.NewBaseCode._2._Services.Addressable;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._1_GameMachine
{
    public class StateSwitcher : MonoBehaviour, IStateSwitcher
    {
        private IGameMachineModule _gameMachineModule;
        private IAddressableLoader _addressableLoader;
        private IInputService _inputService;

        [Inject]
        void Construct
        (
            IGameMachineModule gameMachineModule,
            IAddressableLoader addressableLoader,
            IInputService inputService
        )
        {
            _inputService = inputService;
            _addressableLoader = addressableLoader;
            _gameMachineModule = gameMachineModule;
        }

        public void StartFirstLevel()
        {
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.LoadState);
            _addressableLoader.LoadLevelByIndex(0);
        }

        public void SetGameplayState()
        {
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.GameState);
        }
        
          public void SetMenuState()
        {
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.MenuState);
        }
          
           public void SetPauseState()
        {
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.PauseState);
        }
          
          
        
    }

    public interface IStateSwitcher
    {
        void StartFirstLevel();
        void SetGameplayState();
        void SetMenuState();
        void SetPauseState();
    }
}
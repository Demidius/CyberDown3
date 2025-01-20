using System;
using _2_NewBaseCode.BaseSceneCode._1._GameMachine;
using BsseCode._1._StateMachines.GameStateMachine.States;
using UnityEngine;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine
{
    public interface IGameMachine
    {
        void StartStateMachine();
        void SetState(IGameState newState);
        
        public event Action<IGameState> EnterInState;
    }

    public class GameMachine : IGameMachine
    {
        private IGameState _currentState;
        private IGameMachineModule _gameMachineModule;
        public event Action<IGameState> EnterInState;

        public GameMachine(IGameMachineModule gameMachineModule)
        {
            _gameMachineModule = gameMachineModule;
        }
       
        public void StartStateMachine()
        {
            SetState(_gameMachineModule.BootstrapState);
        }

        public void SetState(IGameState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
            
            EnterInState?.Invoke(_currentState);
        }
    }
}
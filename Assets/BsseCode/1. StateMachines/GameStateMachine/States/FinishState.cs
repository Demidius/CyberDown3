using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices;
using UnityEngine;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class FinishState : IGameState
    {
        public IGameState CurrentState;
        private GameMachineStarter _gameMachineStarter;

        private float _temtTimeSpeed;

        public FinishState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            _gameMachineStarter.uiController.FinishState.SetActive(true);
            Time.timeScale = 0;
        }

        public void Exit()
        {
            Time.timeScale = 1;
            _gameMachineStarter.uiController.FinishState.SetActive(false);
        }
    }
}
using System;
using BsseCode._3._SupportCode.Constants;
using BsseCode._6._Audio.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class MainMenuState : IGameState
    {
        private GameMachineStarter _gameMachineStarter;

        public event Action OnMenuState; 

        public MainMenuState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            OnMenuState?.Invoke();
            Debug.Log("Enter MainMenuState");

            if (_gameMachineStarter?.audioTracksBase?.musicMenu1 == null)
            {
                Debug.LogError("AudioTracksBase or musicMenu1 is null!");
                return;
            }

            if (_gameMachineStarter.vcam == null)
            {
                Debug.LogError("Virtual Camera (vcam) is null!");
                return;
            }

            _gameMachineStarter.audioManager.PlaySound(_gameMachineStarter.audioTracksBase.musicMenu1, useInstance: true,
                position: _gameMachineStarter.vcam.transform.position);

            if (_gameMachineStarter.playerHandler?.CurrentPlayer != null)
                _gameMachineStarter.playerHandler.DestroyPlayer();

            if (_gameMachineStarter.uiController?.BaseMenu?.GameObject() != null && 
                !_gameMachineStarter.uiController.BaseMenu.GameObject().activeSelf)
            {
                _gameMachineStarter.uiController.BaseMenu.GameObject().SetActive(true);
            }

            if (_gameMachineStarter.AddressableLoader != null)
            {
                _gameMachineStarter.AddressableLoader.UnloadCurrentLevel();
            }
            else
            {
                Debug.LogError("AddressableLoader is null!");
            }

            _gameMachineStarter.uiController?.ResultsUI?.DisplayResults();

            _gameMachineStarter.killsController?.ResetKills();
        }


        public void StartGame()
        {
            _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.LoadingState);
            _gameMachineStarter.AddressableLoader.LoadLevelByIndex(0);
        }


        public void Exit()
        {
            _gameMachineStarter.audioManager.StopSound(_gameMachineStarter.audioTracksBase.musicMenu1);
        }
    }
}
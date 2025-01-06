using System;
using Unity.VisualScripting;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class MainMenuState : IGameState
    {
        private readonly GameMachineStarter _gameMachineStarter;

        public event Action OnMenuState;

        public MainMenuState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter ?? throw new ArgumentNullException(nameof(gameMachineStarter));
        }

        public void Enter()
        {
            OnMenuState?.Invoke();
            Debug.Log("Enter MainMenuState");

            if (!ValidateDependencies()) return;

            PlayMenuMusic();
            DestroyExistingPlayer();
            ShowMainMenuUI();
            UnloadCurrentLevel();
            DisplayResultsUI();
            ResetKillsCounter();
        }

        public void StartGame()
        {
            _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.LoadingState);
            _gameMachineStarter.AddressableLoader.LoadLevelByIndex(0);
        }

        public void Exit()
        {
            StopMenuMusic();
        }

        private bool ValidateDependencies()
        {
            if (_gameMachineStarter.vcam == null)
            {
                Debug.LogError("Virtual Camera (vcam) is null!");
                return false;
            }

            if (_gameMachineStarter.AddressableLoader == null)
            {
                Debug.LogError("AddressableLoader is null!");
                return false;
            }

            return true;
        }

        private void PlayMenuMusic()
        {
            _gameMachineStarter.audioManager?.PlaySound(_gameMachineStarter.audioTracksBase.musicMenu1, useInstance: true);
        }

        private void StopMenuMusic()
        {
            _gameMachineStarter.audioManager?.StopSound(_gameMachineStarter.audioTracksBase.musicMenu1);
        }

        private void DestroyExistingPlayer()
        {
            _gameMachineStarter.playerHandler?.DestroyPlayer();
        }

        private void ShowMainMenuUI()
        {
            var baseMenu = _gameMachineStarter.uiController?.BaseMenu?.GameObject();
            if (baseMenu != null && !baseMenu.activeSelf)
            {
                baseMenu.SetActive(true);
            }
        }

        private void UnloadCurrentLevel()
        {
            _gameMachineStarter.AddressableLoader?.UnloadCurrentLevel();
        }

        private void DisplayResultsUI()
        {
            _gameMachineStarter.uiController?.ResultsUI?.DisplayResults();
        }

        private void ResetKillsCounter()
        {
            _gameMachineStarter.killsController?.ResetKills();
        }
    }
}

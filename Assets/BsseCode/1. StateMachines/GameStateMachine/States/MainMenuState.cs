using System;
using BsseCode._2._Services.ServiceLocator;
using Unity.VisualScripting;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class MainMenuState : IGameState
    {
        private readonly GameMachineStarter _gameMachineStarter;
        private IUIServiceLocator _uiServiceLocator;
        private IManagersServiceLocator _managersServiceLocator;
        private IAudioServicesLocator _audioServicesLocator;

        public event Action OnMenuState;

        public MainMenuState(
            GameMachineStarter gameMachineStarter, 
            IUIServiceLocator uiServiceLocator,
            IManagersServiceLocator managersServiceLocator,
            IAudioServicesLocator audioServicesLocator
            )
        {
            _audioServicesLocator = audioServicesLocator;
            _managersServiceLocator = managersServiceLocator;
            _uiServiceLocator = uiServiceLocator;
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

            if (_gameMachineStarter.AddressableLoader == null)
            {
                Debug.LogError("AddressableLoader is null!");
                return false;
            }

            return true;
        }

        private void PlayMenuMusic()
        {
            _audioServicesLocator.AudioManager?.PlaySound(_audioServicesLocator.AudioTracksBase.musicMenu1, useInstance: true);
        }

        private void StopMenuMusic()
        {
            _audioServicesLocator.AudioManager?.StopSound(_audioServicesLocator.AudioTracksBase.musicMenu1);
        }

        private void DestroyExistingPlayer()
        {
            _managersServiceLocator.PlayerHandler?.DestroyPlayer();
        }

        private void ShowMainMenuUI()
        {
            var baseMenu = _uiServiceLocator.UIController?.BaseMenu?.GameObject();
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
            _uiServiceLocator.UIController?.ResultsUI?.DisplayResults();
        }

        private void ResetKillsCounter()
        {
            _managersServiceLocator.KillsController?.ResetKills();
        }
    }
}

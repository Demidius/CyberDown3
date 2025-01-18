using System;
using BsseCode._2._Services.ServiceLocator;
using NewBaseCode._1._GameMachine;
using Unity.VisualScripting;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class MainMenuState : IGameState
    {
        private readonly IGameMachineModule _gameMachineModule;
        private IUIServiceLocator _uiServiceLocator;
        private IManagersServiceLocator _managersServiceLocator;
        private IAudioServicesLocator _audioServicesLocator;
        

        public event Action OnMenuState;

        public MainMenuState(
            IGameMachineModule gameMachineModule,
            IUIServiceLocator uiServiceLocator,
            IManagersServiceLocator managersServiceLocator,
            IAudioServicesLocator audioServicesLocator
        )
        {
            _audioServicesLocator = audioServicesLocator;
            _managersServiceLocator = managersServiceLocator;
            _uiServiceLocator = uiServiceLocator;
            _gameMachineModule = gameMachineModule ?? throw new ArgumentNullException(nameof(gameMachineModule));
        }

        public void Enter()
        {
            OnMenuState?.Invoke();
            Debug.Log("Enter MainMenuState");

            if (!ValidateDependencies()) return;

            PlayMenuMusic();
            DestroyExistingPlayer();
            MainMenuUIToggle(true);
            UnloadCurrentLevel();
            DisplayResultsUI();
            ResetKillsCounter();
        }

        public void StartGame()
        {
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.LoadingState);
            _gameMachineModule.AddressableLoader.LoadLevelByIndex(0);
        }

        public void Exit()
        {
            StopMenuMusic();
            MainMenuUIToggle(false);
        }

        private bool ValidateDependencies()
        {
            if (_gameMachineModule.AddressableLoader == null)
            {
                Debug.LogError("AddressableLoader is null!");
                return false;
            }

            return true;
        }

        private void PlayMenuMusic()
        {
            _audioServicesLocator.AudioManager?.PlaySound(_audioServicesLocator.AudioTracksBase.musicMenu1,
                useInstance: true);
        }

        private void StopMenuMusic()
        {
            _audioServicesLocator.AudioManager?.StopSound(_audioServicesLocator.AudioTracksBase.musicMenu1);
        }

        private void DestroyExistingPlayer()
        {
            _managersServiceLocator.PlayerHandler?.DestroyPlayer();
        }

        private void MainMenuUIToggle(bool status)
        {
            var baseMenu = _uiServiceLocator.UIController?.BaseMenu?.GameObject();
            
            if (baseMenu == null)
                return;

            if (status)
            {
                baseMenu.SetActive(true);
            }
            else
            {
                baseMenu.SetActive(false);
            }
        }

        private void UnloadCurrentLevel()
        {
            _gameMachineModule.AddressableLoader?.UnloadCurrentLevel();
        }

        private void DisplayResultsUI()
        {
            _uiServiceLocator.UIController?.ResultsUI?.DisplayResults();
        }

        private void ResetKillsCounter()
        {
            Debug.Log("Fix It!");
            // _managersServiceLocator.KillsController?.ResetKills();
        }
    }
}
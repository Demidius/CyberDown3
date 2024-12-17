using BsseCode._3._SupportCode.Constants;
using BsseCode._6._Audio.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class MainMenuState : IGameState
    {
        private GameMachineStarter _gameMachineStarter;

        public MainMenuState(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void Enter()
        {
            Debug.Log("Enter MainMenuState");
            AudioManager.Instance.PlaySound(_gameMachineStarter.audioTracksBase.musicMenu1, useInstance: true,
                position: _gameMachineStarter.vcam.transform.position);

            if (_gameMachineStarter.playerHandler.CurrentPlayer != null)
                _gameMachineStarter.playerHandler.DestroyPlayer();

            if (_gameMachineStarter.uiController.BaseMenu.GameObject().activeSelf == false)
                _gameMachineStarter.uiController.BaseMenu.GameObject().SetActive(true);

            _gameMachineStarter.AddressableLoader.UnloadCurrentLevel();
        }

        public void StartGame()
        {
            _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.LoadingState);
            _gameMachineStarter.AddressableLoader.LoadLevelByIndex(0);
        }


        public void Exit()
        {
            AudioManager.Instance.StopSound(_gameMachineStarter.audioTracksBase.musicMenu1);
        }
    }
}
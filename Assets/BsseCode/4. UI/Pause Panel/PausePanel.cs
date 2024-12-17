using BsseCode._1._StateMachines.GameStateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode._4._UI.Pause_Panel
{
    public class PausePanel : MonoBehaviour
    {
       
        [SerializeField] Button exitButton;
        private GameMachineStarter _starter;

        [Inject]
        public void Construct(GameMachineStarter starter)
        {
            _starter = starter;

            exitButton.onClick.AddListener(ExitInMenu);
        }
        void ExitInMenu()
        {
            _starter.PauseState.ReturnToMenu();
        }

        private void OnDestroy()
        {
            exitButton.onClick.RemoveListener(ExitInMenu);
        }
    }
}
using BsseCode._1._StateMachines.GameStateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode._4._UI.Level1UI.Pause_Panel
{
    public class PausePanel : MonoBehaviour
    {
       
        [SerializeField] Button exitButton;
        private IGameMachineModule _module;

        [Inject]
        public void Construct(IGameMachineModule module)
        {
            _module = module;

            exitButton.onClick.AddListener(ExitInMenu);
        }
        void ExitInMenu()
        {
            _module.PauseState.ReturnToMenu();
        }

        private void OnDestroy()
        {
            exitButton.onClick.RemoveListener(ExitInMenu);
        }
    }
}
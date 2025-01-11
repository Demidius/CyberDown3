using BsseCode._1._StateMachines.GameStateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode._4._UI.Level1UI
{
    public class Window1Panel : MonoBehaviour
    {
        [SerializeField] Button nextButton;
        private IGameMachineModule _gameMachineModule;

        [Inject]
        void Construct(IGameMachineModule gameMachineModule)
        {
            _gameMachineModule = gameMachineModule;
        }
        void Start()
        {
            nextButton.onClick.AddListener(OnNewGameButton);
        }

        void OnNewGameButton()
        {
            _gameMachineModule.WindowState.ReturnToGame(false);
        }

    }
}
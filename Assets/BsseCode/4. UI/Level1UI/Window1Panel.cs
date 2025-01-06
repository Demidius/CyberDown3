using BsseCode._1._StateMachines.GameStateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode._4._UI.Level1UI
{
    public class Window1Panel : MonoBehaviour
    {
        [SerializeField] Button nextButton;
        private GameMachineStarter _gameMachineStarter;

        [Inject]
        void Construct(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }
        void Start()
        {
            nextButton.onClick.AddListener(OnNewGameButton);
        }

        void OnNewGameButton()
        {
            _gameMachineStarter.WindowState.ReturnToGame(false);
        }

    }
}
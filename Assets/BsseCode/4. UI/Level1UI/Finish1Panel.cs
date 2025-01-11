using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.LevelServices.GameResults;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode._4._UI.Level1UI
{
    public class Finish1Panel : MonoBehaviour
    {
        [SerializeField] Button returnToMemuButton;
        private IGameMachineModule _gameMachineModule;
        private KillsController _killsController;

        [Inject]
        void Construct(IGameMachineModule gameMachineModule, KillsController killsController )
        {
            _killsController = killsController;
            _gameMachineModule = gameMachineModule;
        }
        void Start()
        {
            returnToMemuButton.onClick.AddListener(OnMenuButton);
        }

        void OnMenuButton()
        {
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.MenuState);
            _killsController.EndGame();
        }

    }
}
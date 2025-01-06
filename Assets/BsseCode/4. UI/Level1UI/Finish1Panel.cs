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
        private GameMachineStarter _gameMachineStarter;
        private KillsController _killsController;

        [Inject]
        void Construct(GameMachineStarter gameMachineStarter, KillsController killsController )
        {
            _killsController = killsController;
            _gameMachineStarter = gameMachineStarter;
        }
        void Start()
        {
            returnToMemuButton.onClick.AddListener(OnMenuButton);
        }

        void OnMenuButton()
        {
            _gameMachineStarter.GameStateMachine.SetState(_gameMachineStarter.MainMenuState);
            _killsController.EndGame();
        }

    }
}
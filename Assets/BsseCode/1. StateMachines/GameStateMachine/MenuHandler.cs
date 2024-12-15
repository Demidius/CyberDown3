using BsseCode._1._StateMachines.GameStateMachine.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine
{
    public class MenuHandler : MonoBehaviour
    {
        [SerializeField] private Button button;
        private GameMachineStarter _starter;

        [Inject]
        public void Construct(GameMachineStarter starter)
        {
            _starter = starter;
        }

        private void Start()
        {
            button.onClick.AddListener(OnStartButtonClicked);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnStartButtonClicked);
        }


        public void OnStartButtonClicked()
        {
            _starter.BootstrapState.StartGame();
        }
    }
}
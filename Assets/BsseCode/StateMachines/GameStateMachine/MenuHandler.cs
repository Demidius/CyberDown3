using BsseCode.StateMachines.GameStateMachine.States;
using UnityEngine;
using UnityEngine.UI; 
using Zenject;

namespace BsseCode.StateMachines.GameStateMachine
{
    public class MenuHandler : MonoBehaviour
    {
        [SerializeField] private Button _button; 
        
        private MainMenuState _mainMenuState;

        [Inject]
        public void Construct(MainMenuState mainMenuState)
        {
            _mainMenuState = mainMenuState;
        }

        private void Awake()
        {
            _button.onClick.AddListener(OnStartButtonClicked);
        }

        private void OnDestroy()
        {
          _button.onClick.RemoveListener(OnStartButtonClicked);
        }

        private void OnStartButtonClicked()
        {
            _mainMenuState.StartGame();
        }
    }
}
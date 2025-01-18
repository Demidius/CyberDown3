using BsseCode._1._StateMachines.GameStateMachine;
using NewBaseCode._1._GameMachine.States;
using NewBaseCode.UI;
using UnityEngine;
using Zenject;

namespace NewBaseCode._1._GameMachine
{
    public class GameMachineModule : MonoBehaviour, IGameMachineModule
    {
        private IMenuPanelsController _menuPanelsController;
        
        public IGameMachine GameMachine { get; private set; }
        public BootstrapState BootstrapState { get; private set; }
        public MainMenuState MenuState { get; private set; }

        
        [Inject]
        void Construct(IMenuPanelsController menuPanelsController)
        {
            _menuPanelsController = menuPanelsController;
        }

        private void Awake()
        {
            CreateStarterStates();
            CreateBasicStates();

            GameMachine.StartStateMachine();
        }

        private void CreateBasicStates()
        {
            MenuState = new MainMenuState(this, _menuPanelsController);
        }

        private void CreateStarterStates()
        {
            BootstrapState = new BootstrapState(this);
            GameMachine = new GameMachine(this);
        }
    }

    public interface IGameMachineModule
    {
        public IGameMachine GameMachine { get; }
        public BootstrapState BootstrapState { get; }
        public MainMenuState MenuState { get; }
    }
}
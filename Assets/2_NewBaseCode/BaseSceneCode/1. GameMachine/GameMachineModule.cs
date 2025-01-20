using _2_NewBaseCode.BaseSceneCode._1._GameMachine.States;
using _2_NewBaseCode.BaseSceneCode._3._UI._1.Controllers;
using _2_NewBaseCode.BaseSceneCode._4._Audio;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._1._GameMachine
{
    public class GameMachineModule : MonoBehaviour, IGameMachineModule
    {
        private IMenuPanelsController _menuPanelsController;
        private IMusicController _musicController;
        private ILoadPanelController _loadPanelController;

        public IGameMachine GameMachine { get; private set; }
        public BootstrapState BootstrapState { get; private set; }
        public MainMenuState MenuState { get; private set; }
        public GameState GameState { get; private set; }
        public LoadState LoadState { get; private set; }

        
        [Inject]
        void Construct(
            IMenuPanelsController menuPanelsController,
            IMusicController musicController,
            ILoadPanelController loadPanelController)
        {
            _loadPanelController = loadPanelController;
            _musicController = musicController;
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
            MenuState = new MainMenuState(this, _menuPanelsController, _musicController);
        }

        private void CreateStarterStates()
        {
            BootstrapState = new BootstrapState(this);
            GameState = new GameState(this);
            GameMachine = new GameMachine(this);
            LoadState = new LoadState(this, _loadPanelController);
        }
    }

    public interface IGameMachineModule
    {
        public IGameMachine GameMachine { get; }
        public BootstrapState BootstrapState { get; }
        public MainMenuState MenuState { get; }
        public GameState GameState { get; }
        public LoadState LoadState { get; }
    }
}
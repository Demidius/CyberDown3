using System;
using _2_NewBaseCode.BaseSceneCode._1_GameMachine.States;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol;
using _2_NewBaseCode.BaseSceneCode._3._UI._1.Controllers;
using _2_NewBaseCode.BaseSceneCode._4._Audio;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._1_GameMachine
{
    public class GameMachineModule : MonoBehaviour, IGameMachineModule
    {
        private IMenuPanelsController _menuPanelsController;
        private IMusicController _musicController;
        private ILoadPanelController _loadPanelController;
        private IInputSwitcher _inputSwitcher;
        private IStateSwitcher _stateSwitcher;
        private IInputService _inputService;

        public IGameMachine GameMachine { get; private set; }
        public BootstrapState BootstrapState { get; private set; }
        public MainMenuState MenuState { get; private set; }
        public GameState GameState { get; private set; }
        public LoadState LoadState { get; private set; }
        public PauseState PauseState { get; private set; }
        

        
        [Inject]
        void Construct(
            IMenuPanelsController menuPanelsController,
            IMusicController musicController,
            ILoadPanelController loadPanelController,
            IInputSwitcher inputSwitcher,
            IInputService inputService,
            IStateSwitcher stateSwitcher
            )
        {
            _inputService = inputService;
            _inputSwitcher = inputSwitcher;
            _stateSwitcher = stateSwitcher;
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

        private void Update()
        {
            GameMachine.CurrentState.Update();
        }

        private void CreateBasicStates()
        {
            MenuState = new MainMenuState(this, _menuPanelsController, _musicController, _inputSwitcher);
        }

        private void CreateStarterStates()
        {
            BootstrapState = new BootstrapState(this, _stateSwitcher);
            GameState = new GameState(this, _inputSwitcher, _inputService, _stateSwitcher );
            GameMachine = new GameMachine(this);
            LoadState = new LoadState(this, _loadPanelController);
            PauseState = new PauseState(this, _inputSwitcher, _inputService, _stateSwitcher );
        }
    }

    public interface IGameMachineModule
    {
        public IGameMachine GameMachine { get; }
        public BootstrapState BootstrapState { get; }
        public MainMenuState MenuState { get; }
        public GameState GameState { get; }
        public LoadState LoadState { get; }
        public PauseState PauseState { get; }
    }
}
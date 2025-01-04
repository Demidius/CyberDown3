using BsseCode._1._StateMachines.GameStateMachine.States;
using BsseCode._2._Services.GlobalServices.Addressable;
using BsseCode._2._Services.GlobalServices.BeaconHandler;
using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.PlayerHandlerFl;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._4._UI;
using BsseCode._5._GameEntities.Objects;
using BsseCode._6._Audio.Data;
using BsseCode._6._Audio.Managers;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine
{
    public class GameMachineStarter : MonoBehaviour
    {
        [Inject]
        void Construct(
            IAddressableLoader loader,
            UIController uiController,
            PlayerHandler playerHandler,
            IInputGlobalService pcInputGlobalService,
            ITimeGlobalService timeGlobalService,
            AudioTracksBase audioTracksBase,
            CinemachineVirtualCamera vcam,
            ResultsManager resultsManager,
            KillsController killsController,
            BeaconHandler beaconHandler,
            AudioManager audioManager
            )
        {
            this.audioManager = audioManager;
            this.beaconHandler = beaconHandler;
            this.killsController = killsController;
            this.resultsManager = resultsManager;
            this.vcam = vcam;
            this.audioTracksBase = audioTracksBase;
            TimeGlobalService = timeGlobalService;
            PCInputGlobalService = pcInputGlobalService;
            this.playerHandler = playerHandler;
            this.uiController = uiController;
            AddressableLoader = loader;
        }


        public GameStateMachine GameStateMachine;
        public BootstrapState BootstrapState;
        public GameplayState GameplayState;
        public GameOverState GameOverState;
        public MainMenuState MainMenuState;
        public PauseState PauseState;
        public WindowState WindowState;
        public LoadingState LoadingState;
        
        public IAddressableLoader AddressableLoader;
        
        public UIController uiController;
        public PlayerHandler playerHandler;
        public IInputGlobalService PCInputGlobalService;
        public ITimeGlobalService TimeGlobalService;
        public AudioTracksBase audioTracksBase;
        public CinemachineVirtualCamera vcam;
        public ResultsManager resultsManager;
        public KillsController killsController;
        public BeaconHandler beaconHandler;
        public AudioManager audioManager;

        private void Awake()
        {
            BootstrapState = new BootstrapState(this);
            GameplayState = new GameplayState(this);
            GameOverState = new GameOverState(this);
            MainMenuState = new MainMenuState(this);
            LoadingState = new LoadingState(this);
            GameStateMachine = new GameStateMachine(this);
            PauseState = new PauseState(this);
            WindowState = new WindowState(this);

            Debug.Log("Game machine starter started");
            GameStateMachine.Start();
        }


        private void Update()
        {
            PCInputGlobalService.PauseInput();
        }
    }
}
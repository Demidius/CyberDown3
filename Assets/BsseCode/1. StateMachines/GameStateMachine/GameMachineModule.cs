using BsseCode._1._StateMachines.GameStateMachine.States;
using BsseCode._2._Services.GlobalServices.Addressable;
using BsseCode._2._Services.ServiceLocator;
using UnityEngine;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine
{
    public class GameMachineModule : MonoBehaviour, IGameMachineModule
    {
        [Inject]
        void Construct(
            IAddressableLoader loader,
            IAudioServicesLocator audioServicesLocator,
            ICameraServiceLocator cameraServiceLocator,
            IReusableServiceLocator reusableServiceLocator,
            IManagersServiceLocator managersServiceLocator,
            IUIServiceLocator uiServiceLocator)
        {
            _audioServiceLocator = audioServicesLocator;
            _cameraServiceLocator = cameraServiceLocator;
            _reusableServiceLocator = reusableServiceLocator;
            _managersServiceLocator = managersServiceLocator;
            _uiServiceLocator = uiServiceLocator;

            AddressableLoader = loader;
        }

        public IGameMachine Machine { get; private set; }
        public BootstrapState BootstrapState { get; private set; }
        public GameplayState GameplayState { get; private set; }
        public MainMenuState MenuState { get; private set; }

        public PauseState PauseState { get; private set; }
        public WindowState WindowState { get; private set; }
        public LoadingState LoadingState { get; private set; }
        public FinishState FinishState { get; private set; }
        public ResetState ResetState { get; private set; }

        public LandingState LandingState { get; private set; }
        public IAddressableLoader AddressableLoader { get; private set; }

        private IUIServiceLocator _uiServiceLocator;
        private IManagersServiceLocator _managersServiceLocator;
        private IReusableServiceLocator _reusableServiceLocator;
        private ICameraServiceLocator _cameraServiceLocator;
        private IAudioServicesLocator _audioServiceLocator;


        private void Awake()
        {
            CreateStarterStates();
            CreateBasicStates();
            CreateLevelStates();

            Machine.StartStateMachine();
        }

        private void CreateBasicStates()
        {
            GameplayState =
                new GameplayState(this, _uiServiceLocator, _managersServiceLocator, _reusableServiceLocator);
            MenuState = new MainMenuState(this, _uiServiceLocator, _managersServiceLocator, _audioServiceLocator);
            LoadingState = new LoadingState(this);
        }

        private void CreateStarterStates()
        {
            BootstrapState = new BootstrapState(this);
            Machine = new GameMachine(this);
        }

        private void CreateLevelStates()
        {
            PauseState = new PauseState(this, _uiServiceLocator, _reusableServiceLocator);
            WindowState = new WindowState(this, _uiServiceLocator, _reusableServiceLocator);
            FinishState = new FinishState(this, _uiServiceLocator);
            ResetState = new ResetState(this, _uiServiceLocator, _managersServiceLocator);
            LandingState = new LandingState(this, _reusableServiceLocator, _reusableServiceLocator);
        }


        private void Update()
        {
            _reusableServiceLocator.PCInputGlobalService.PauseInput();
        }
    }

    public interface IGameMachineModule
    {
        public IGameMachine Machine { get; }
        public BootstrapState BootstrapState { get; }
        public GameplayState GameplayState { get; }
        public MainMenuState MenuState { get; }

        public PauseState PauseState { get; }
        public WindowState WindowState { get; }
        public LoadingState LoadingState { get; }
        public FinishState FinishState { get; }
        public ResetState ResetState { get; }
        
        public LandingState LandingState { get; }
        public IAddressableLoader AddressableLoader { get; }
    }
}
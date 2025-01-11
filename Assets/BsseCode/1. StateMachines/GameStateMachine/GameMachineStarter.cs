using BaseCode2._2._Services.Addressable;
using BsseCode._1._StateMachines.GameStateMachine.States;
using BsseCode._2._Services.ServiceLocator;
using UnityEngine;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine
{
    public class GameMachineStarter : MonoBehaviour
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
            AudioServiceLocator = audioServicesLocator;
            CameraServiceLocator = cameraServiceLocator;
            ReusableServiceLocator = reusableServiceLocator;
            ManagersServiceLocator = managersServiceLocator;
            UIServiceLocator = uiServiceLocator;
            
            AddressableLoader = loader;
        }

        public GameStateMachine GameStateMachine;
        public BootstrapState BootstrapState;
        public GameplayState GameplayState;
        public MainMenuState MainMenuState;
        
        public PauseState PauseState;
        public WindowState WindowState;
        public LoadingState LoadingState;
        public FinishState FinishState;
        public ResetState ResetState;
        
        public LandingState LandingState;
        public IAddressableLoader AddressableLoader;
       
        public IUIServiceLocator UIServiceLocator;
        public IManagersServiceLocator ManagersServiceLocator;
        public IReusableServiceLocator ReusableServiceLocator;
        public ICameraServiceLocator CameraServiceLocator;
        public IAudioServicesLocator AudioServiceLocator;


        private void Awake()
        {
            GreateStarterStates();
            GreateBasicStates();
            CreateLevelStates();

            GameStateMachine.StartStateMachine();
        }

        private void GreateBasicStates()
        {
            GameplayState = new GameplayState(this, UIServiceLocator, ManagersServiceLocator, ReusableServiceLocator);
            MainMenuState = new MainMenuState(this, UIServiceLocator, ManagersServiceLocator, AudioServiceLocator);
            LoadingState = new LoadingState(this);
        }

        private void GreateStarterStates()
        {
            BootstrapState = new BootstrapState(this);
            GameStateMachine = new GameStateMachine(this);
        }

        private void CreateLevelStates()
        {
            PauseState = new PauseState(this, UIServiceLocator, ReusableServiceLocator);
            WindowState = new WindowState(this, UIServiceLocator, ReusableServiceLocator);
            FinishState = new FinishState(this, UIServiceLocator);
            ResetState = new ResetState(this, UIServiceLocator, ManagersServiceLocator);
            LandingState = new LandingState(this, ReusableServiceLocator, ReusableServiceLocator);
        }


        private void Update()
        {
            ReusableServiceLocator.PCInputGlobalService.PauseInput();
        }
    }
}
using BsseCode._1._StateMachines.GameStateMachine.States;
using BsseCode._2._Services.GlobalServices.Addressable;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine
{
    public class GameMachineStarter : MonoBehaviour
    {
        [Inject]
        void Construct(IAddressableLoader loader)
        {
            _loader = loader;
        }
        
        
        public GameStateMachine GameStateMachine;
        public BootstrapState BootstrapState;
        public GameplayState GameplayState;
        public GameOverState GameOverState;
        public MainMenuState MainMenuState;
        public PauseState PauseState;
        public LoadingState LoadingState;
        private IAddressableLoader _loader;

        private void Awake()
        {
            BootstrapState = new BootstrapState(this, _loader);
            GameplayState = new GameplayState( this);
            GameOverState = new GameOverState(this);
            MainMenuState = new MainMenuState(this);
            PauseState = new PauseState( this);
            LoadingState = new LoadingState( this);
            GameStateMachine = new GameStateMachine(this);
            
            GameStateMachine.Start();
        }
    }
}
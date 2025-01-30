namespace _2_NewBaseCode.BaseSceneCode._1_GameMachine.States
{
    public class BootstrapState : IGameState
        {
        private IGameMachineModule _gameMachineModule;
        private IStateSwitcher _stateSwitcher;

        public BootstrapState (
            IGameMachineModule gameMachineModule,
            IStateSwitcher stateSwitcher
            )
        {
            _stateSwitcher = stateSwitcher;
            _gameMachineModule = gameMachineModule;
        }

        public void Enter()
        {
            _stateSwitcher.SetMenuState();
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
           
        }
    }
}
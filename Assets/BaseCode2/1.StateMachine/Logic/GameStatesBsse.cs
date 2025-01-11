using BaseCode2._1.StateMachine.GameStates;
using UnityEngine;

namespace BaseCode2._1.StateMachine.Logic
{
    public class GameStatesBase : MonoBehaviour, IGameStatesBase
    {
        public Base_BootstrapState BootstrapState { get; private set; }
        public Base_LoadingState LoadingState { get; private set; }
        public Base_MainMenuState MainMenuState { get; private set; }
        public Level_GameplayState GameplayState { get; private set; }
        public Level_PauseState PauseState { get; private set; }
        public Level_WindowState WindowState { get; private set; }
        public Level_FinishState FinishState { get; private set; }
        public Level_ResetState ResetState { get; private set; }
        public GameStateMachine GameStateMachine { get; private set; }

        public void Awake()
        {
            BootstrapState = new Base_BootstrapState();
            LoadingState = new Base_LoadingState();
            MainMenuState = new Base_MainMenuState();
            GameplayState = new Level_GameplayState();
            PauseState = new Level_PauseState();
            WindowState = new Level_WindowState();
            FinishState = new Level_FinishState();
            ResetState = new Level_ResetState();
            GameStateMachine = new GameStateMachine();
        }
    }

    public interface IGameStatesBase
    {
        Base_BootstrapState BootstrapState { get; }
        Base_LoadingState LoadingState { get; }
        Base_MainMenuState MainMenuState { get; }
        Level_GameplayState GameplayState { get; }
        Level_PauseState PauseState { get; }
        Level_WindowState WindowState { get; }
        Level_FinishState FinishState { get; }
        Level_ResetState ResetState { get; }
        GameStateMachine GameStateMachine { get; }
    }
}
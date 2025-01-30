using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol
{
    public class InputSwitcher : MonoBehaviour, IInputSwitcher
    {
        public bool OnGameInputState { get; private set; }
        public bool OnMenuInputState { get; private set; }
        public bool OnPauseInputState { get; private set; }

        public void SetMenuInput()
        {
            OnGameInputState = false;
            OnMenuInputState = true;
            OnPauseInputState = false;
        }
        
        public void SetGameInput()
        {
            OnGameInputState = true;
            OnMenuInputState = false;
            OnPauseInputState = false;
        }
        
         public void SetPauseInput()
        {
            OnGameInputState = false;
            OnMenuInputState = false;
            OnPauseInputState = true;
        }
        
    }

    public interface IInputSwitcher
    {
        public bool OnGameInputState { get; }
        public bool OnMenuInputState { get; }
        public bool OnPauseInputState { get; }

        public void SetMenuInput();
        public void SetGameInput();
        public void SetPauseInput();
    }
}
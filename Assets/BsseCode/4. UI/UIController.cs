using BsseCode._2._Services.LevelServices.GameResults;
using UnityEngine;

namespace BsseCode._4._UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject hud;
        [SerializeField] private GameObject baseMenu;
        [SerializeField] private GameObject slowMotionHUD;
        [SerializeField] private GameObject cursorToSprite;
        [SerializeField] private ResultsUI resultsUI;

        [SerializeField] private GameObject window1Panel;
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject finishState;

        public GameObject HUD
        {
            get => hud;
            set => hud = value;
        }

        public GameObject Window1Panel 
        {
            get => window1Panel;
            set => window1Panel = value;
        }

        public GameObject FinishState
        {
            get => finishState;
            set => finishState = value;
        }

        public GameObject BaseMenu
        {
            get => baseMenu;
            set => baseMenu = value;
        }

        public GameObject PausePanel
        {
            get => pausePanel;
            set => pausePanel = value;
        }

        public GameObject SlowMotionHUD
        {
            get => slowMotionHUD;
            set => slowMotionHUD = value;
        }

        public GameObject CursorToSprite
        {
            get => cursorToSprite;
            set => cursorToSprite = value;
        }

        public ResultsUI ResultsUI
        {
            get => resultsUI;
            set => resultsUI = value;
        }
    }
}
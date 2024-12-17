using UnityEngine;

namespace BsseCode._4._UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject hud;
        [SerializeField] private GameObject baseMenu;
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject slowMotionHUD;
        [SerializeField] private GameObject cursorToSprite;

        public GameObject HUD
        {
            get => hud;
            set => hud = value;
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
    }

}
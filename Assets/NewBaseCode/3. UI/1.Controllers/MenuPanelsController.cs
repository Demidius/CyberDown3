using NewBaseCode._2._Sevices.ColorHeaders;
using NewBaseCode._3._UI._2.Pannels;
using UnityEngine;

namespace NewBaseCode._3._UI._1.Controllers
{
    public class MenuPanelsController : MonoBehaviour, IMenuPanelsController
    {
        [ColoredHeader("MenuPanel", NamedColor.Orange, 14)] [SerializeField]
        private BasePanel menuPanel;

        [ColoredHeader("GameStartPanel", NamedColor.Orange, 14)] [SerializeField]
        private BasePanel gameStartPanel;

        [ColoredHeader("SettingsPanel", NamedColor.Orange, 14)] [SerializeField]
        private BasePanel settingsPanel;

        [ColoredHeader("AuthorsPanel", NamedColor.Orange, 14)] [SerializeField]
        private BasePanel authorsPanel;

        [ColoredHeader("ExitPanel", NamedColor.Orange, 14)] [SerializeField]
        private BasePanel exitPanel;

        

        public void CloseAllPanels()
        {
            menuPanel.Deactivate();
            gameStartPanel.Deactivate();
            settingsPanel.Deactivate();
            authorsPanel.Deactivate();
            exitPanel.Deactivate();
        }

        public void EnterOnMenu()
        {
            CloseAllPanels();
            menuPanel.Activate();
        }

        public void EnterOnGameStartPanel()
        {
            CloseAllPanels();
            gameStartPanel.Activate();
        }
        
        public void EnterOnSettingsPanel()
        {
            CloseAllPanels();
            settingsPanel.Activate();
        }
        public void EnterOnAuthorsPanel()
        {
            CloseAllPanels();
            authorsPanel.Activate();
        }
        
          public void EnterOnExitPanel()
        {
            CloseAllPanels();
            exitPanel.Activate();
        }
        
        
    }

    public interface IMenuPanelsController
    {
        public void EnterOnMenu();
        public void EnterOnGameStartPanel();
        public void CloseAllPanels();
        void EnterOnSettingsPanel();
        void EnterOnAuthorsPanel();
        void EnterOnExitPanel();
    }
}
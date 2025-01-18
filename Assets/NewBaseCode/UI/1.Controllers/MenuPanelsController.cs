using NewBaseCode.Sevices.ColorHeaders;
using UnityEngine;

namespace NewBaseCode.UI
{
    public class MenuPanelsController : MonoBehaviour, IMenuPanelsController
    {
        [ColoredHeader("Menu", NamedColor.Orange, 14)] 
        [SerializeField]
        private IBasePanel _menuPanel;

        [ColoredHeader("GameSelection", NamedColor.Orange, 14)] 
        [SerializeField]
        private IBasePanel _gameStartPanel;

        private void Awake()
        {
            CloseAllPanels();
        }

        public void CloseAllPanels()
        {
            _menuPanel.Deactivate();
            _gameStartPanel.Deactivate();
        }

        public void EnterOnMenu()
        {
            CloseAllPanels();
            _menuPanel.Activate();
        }

        public void EnterOnGameStartPanel()
        {
            CloseAllPanels();
            _gameStartPanel.Activate();
        }
    }

    public interface IMenuPanelsController
    {
        public void EnterOnMenu();
        public void EnterOnGameStartPanel();
        public void CloseAllPanels();
    }
}
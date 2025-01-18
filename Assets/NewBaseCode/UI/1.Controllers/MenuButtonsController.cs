using System;
using NewBaseCode.Sevices.ColorHeaders;
using NewBaseCode.UI.MenuPanel;
using UnityEngine;
using Zenject;

namespace NewBaseCode.UI._1.Controllers
{
    public class MenuButtonsController : MonoBehaviour, IMenuButtonsController
    {
        [ColoredHeader("BaseMenuPanel", NamedColor.Orange, 14)] 
        [SerializeField]
        private IBaseMenuButton _onStartMenuButton;
        
        [ColoredHeader("StartMenuPanel", NamedColor.Orange, 14)] 
        [SerializeField]
        private IBaseMenuButton _onMenuButton;

        private IMenuPanelsController _panelsController;

        [Inject]
        void Construct(IMenuPanelsController panelsController)
        {
            _panelsController = panelsController;
        }
        
        private void Start()
        {
            _onStartMenuButton.ButtonAddListener(_panelsController.EnterOnGameStartPanel);
        }
    }

    public interface IMenuButtonsController
    {
    }
}
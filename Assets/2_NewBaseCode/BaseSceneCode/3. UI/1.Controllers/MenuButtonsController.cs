using System.Collections.Generic;
using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.ColorHeaders;
using _2_NewBaseCode.BaseSceneCode._3._UI._3.Buttons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._3._UI._1.Controllers
{
    public class MenuButtonsController : MonoBehaviour
    {
        [ColoredHeader("Button_onMenu", NamedColor.Orange, 14)] [SerializeField]
        private List<BaseMenuButton> onMenuButtons;

        [ColoredHeader("Button_onStartMenu", NamedColor.Orange, 14)] [SerializeField]
        private List<BaseMenuButton> onStartMenuButtons;

        [ColoredHeader("Button_onSettings", NamedColor.Orange, 14)] [SerializeField]
        private List<BaseMenuButton> onSettingsButtons;

        [ColoredHeader("Button_onAuthors", NamedColor.Orange, 14)] [SerializeField]
        private List<BaseMenuButton> onAuthorsButtons;

        [ColoredHeader("Button_onExit", NamedColor.Orange, 14)] [SerializeField]
        private List<BaseMenuButton> onExitButtons;


        private IMenuPanelsController _panelsController;

        [Inject]
        void Construct(IMenuPanelsController panelsController)
        {
            _panelsController = panelsController;
        }

        private void Start()
        {
            AddListenersToButtons(onMenuButtons, _panelsController.EnterOnMenu);
            AddListenersToButtons(onStartMenuButtons, _panelsController.EnterOnGameStartPanel);
            AddListenersToButtons(onSettingsButtons, _panelsController.EnterOnSettingsPanel);
            AddListenersToButtons(onAuthorsButtons, _panelsController.EnterOnAuthorsPanel);
            AddListenersToButtons(onExitButtons, _panelsController.EnterOnExitPanel);
        }

        private void AddListenersToButtons(List<BaseMenuButton> buttons, UnityEngine.Events.UnityAction action)
        {
            if (buttons == null)
            {
                Debug.LogError("Buttons list is null.");
                return;
            }

            foreach (var button in buttons)
            {
                if (button == null)
                {
                    Debug.LogWarning("One of the buttons in the list is null.");
                    continue;
                }

                // Временная активация объекта, если он отключен
                bool wasActive = button.gameObject.activeSelf;
                if (!wasActive)
                {
                    button.gameObject.SetActive(true);
                }

                button.gameObject.GetComponent<Button>().onClick.AddListener(action);
                
                // Возвращение объекта в исходное состояние
                if (!wasActive)
                {
                    button.gameObject.SetActive(false);
                }
            }
        }

    }
}
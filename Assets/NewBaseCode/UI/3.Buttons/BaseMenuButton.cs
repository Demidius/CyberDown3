using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NewBaseCode.UI.MenuPanel
{
    public class BaseMenuButton : MonoBehaviour, IBaseMenuButton
    {
        private Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void ButtonAddListener(UnityAction method)
        {
            _button.onClick.AddListener(method);
        }
    }

    public interface IBaseMenuButton
    {
        void ButtonAddListener(UnityAction method);
    }
}
using System;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace BsseCode._4._UI.BaseMenu
{
    public class ButtonTextBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private TextMeshProUGUI _buttonText;
        private Color tempColor;

        void Start()
        {
            _buttonText = GetComponent<TextMeshProUGUI>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_buttonText == null)
            {
                Debug.LogError("TextMeshProUGUI не найден на этом объекте");
                return;
            }

            tempColor = _buttonText.color;
            Color c = _buttonText.color;
            c.r = Mathf.Clamp01(c.r + 151f);
            _buttonText.color = c;
        }

        private void OnDisable()
        {
            if (tempColor != Color.clear)
                _buttonText.color = tempColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _buttonText.color = tempColor;
        }
    }
}
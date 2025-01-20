using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices._1._Const;
using _2_NewBaseCode.BaseSceneCode._4._Audio.Data;
using _2_NewBaseCode.BaseSceneCode._4._Audio.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._3._UI._3.Buttons
{
    public class BaseMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private ButtonScaleWithDOTween _buttonScaler;
        private BottonClickSound _buttonClickSound;

        private const float HoverScale = Const1.HoverScale; // Размер при наведении
        private const float AnimationDuration = Const1.AnimationDuration; // Длительность анимации

        [Inject]
        public void Construct(IAudioManager audioManager, AudioTracksBase audioTracks)
        {
            _buttonClickSound = new BottonClickSound(audioManager, audioTracks);
        }

        void Awake()
        {
            var rectTransform = GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                _buttonScaler = new ButtonScaleWithDOTween(rectTransform, HoverScale, AnimationDuration);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _buttonScaler?.ScaleUp();
            _buttonClickSound?.PlayEnterSound();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _buttonScaler?.ScaleDown();
            _buttonClickSound?.PlayExitSound();
        }
    }
}
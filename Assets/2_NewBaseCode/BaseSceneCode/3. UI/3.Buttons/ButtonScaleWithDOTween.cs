using DG.Tweening;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._3._UI._3.Buttons
{
    public class ButtonScaleWithDOTween
    {
        private readonly RectTransform _rectTransform;
        private readonly float _hoverScale;
        private readonly float _animationDuration;
        private readonly Vector3 _originalScale;

        public ButtonScaleWithDOTween(RectTransform rectTransform, float hoverScale = 1.1f, float animationDuration = 0.2f)
        {
            _rectTransform = rectTransform;
            _hoverScale = hoverScale;
            _animationDuration = animationDuration;
            _originalScale = rectTransform.localScale;
        }

        public void ScaleUp()
        {
            _rectTransform?.DOScale(_originalScale * _hoverScale, _animationDuration).SetEase(Ease.OutBack);
        }

        public void ScaleDown()
        {
            _rectTransform?.DOScale(_originalScale, _animationDuration).SetEase(Ease.OutBack);
        }
    }
}
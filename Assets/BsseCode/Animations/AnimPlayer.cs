using BsseCode.Caracters.Hero.Components;
using BsseCode.Constants;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace BsseCode.Animations
{
    public class AnimPlayer : MonoBehaviour
    {
        [SerializeField] private Animator legsAnimator;
        [SerializeField] private MoveHendler move;

        private ITimeService _timeService;

        [Inject]
        public void Construct(ITimeService timeService)
        {
            _timeService = timeService;
        }

        private void Update()
        {
            if (move.movementHeroDirection != Vector2.zero)
            {
                legsAnimator.SetBool(Constants.Const.Run, true);
            }
            else
            {
                legsAnimator.SetBool(Constants.Const.Run, false);
            }


            legsAnimator.speed = Mathf.Clamp(_timeService.TimeScale, 0.6f, 1.0f);
        }
    }
}
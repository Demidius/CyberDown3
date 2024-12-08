using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._3._SupportCode.Constants;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Hero
{
    public class HeroAnimationController : MonoBehaviour
    {
        private Animator legsAnimator;
        private ITimeGlobalService _timeGlobalService;
        private Player _player;


        [Inject]
        public void Construct(ITimeGlobalService timeGlobalService, Player player)
        {
            _player = player;
            _timeGlobalService = timeGlobalService;
        }

        private void Start()
        {
            legsAnimator = _player.LegsRotaionHero.GetComponentInChildren<Animator>();
            _player.MoveHandler.OnMovementStateChanged += Run;
        }


        private void Run()
        {
            legsAnimator.SetBool(Const.Run, _player.MoveHandler.IsMoving);
        }

        private void Update()
        {
            legsAnimator.speed = Mathf.Clamp(_timeGlobalService.TimeScale, 0.5f, 0.8f);
        }

        private void OnDestroy()
        {
            _player.MoveHandler.OnMovementStateChanged -= Run;
        }
    }
}
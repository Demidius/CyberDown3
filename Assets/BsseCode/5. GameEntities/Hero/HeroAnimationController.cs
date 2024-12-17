using BsseCode._2._Services.GlobalServices.PlayerHandler;
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
        private PlayerHandler _playerHandler;


        [Inject]
        public void Construct(ITimeGlobalService timeGlobalService, PlayerHandler playerHandler)
        {
            _playerHandler = playerHandler;
            _timeGlobalService = timeGlobalService;
        }

        private void Start()
        {
            legsAnimator = _playerHandler.CurrentPlayer.LegsRotaionHero.GetComponentInChildren<Animator>();
            _playerHandler.CurrentPlayer.MoveHandler.OnMovementStateChanged += Run;
        }


        private void Run()
        {
            legsAnimator.SetBool(Const.Run, _playerHandler.CurrentPlayer.MoveHandler.IsMoving);
        }

        private void Update()
        {
            legsAnimator.speed = Mathf.Clamp(_timeGlobalService.TimeScale, 0.5f, 0.8f);
        }

        private void OnDestroy()
        {
            _playerHandler.CurrentPlayer.MoveHandler.OnMovementStateChanged -= Run;
        }
    }
}
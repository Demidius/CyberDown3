using BsseCode._2._Services.GlobalServices.PlayerHandlerFl;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices.TimeProvider;
using BsseCode._3._SupportCode.Constants;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Hero
{
    public class HeroAnimationController : MonoBehaviour
    {
        private Animator legsAnimator;
        
        private PlayerHandler _playerHandler;
        private ITimeModule _timeModule;


        [Inject]
        public void Construct(ITimeModule timeModule, PlayerHandler playerHandler)
        {
            _timeModule = timeModule;
            _playerHandler = playerHandler;
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
            legsAnimator.speed = Mathf.Clamp(_timeModule.GetTimeDeltaTime(), 0.5f, 0.8f);
        }

        private void OnDestroy()
        {
            _playerHandler.CurrentPlayer.MoveHandler.OnMovementStateChanged -= Run;
        }
    }
}
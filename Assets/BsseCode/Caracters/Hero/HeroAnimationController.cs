using System;
using BsseCode.Services.InputFol;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Caracters.Hero
{
    public class HeroAnimationController : MonoBehaviour
    {
        private Animator legsAnimator;
        private ITimeService _timeService;
        private Player _player;
        private IInputService _inputService;


        [Inject]
        public void Construct(ITimeService timeService, Player player, IInputService inputService)
        {
            _inputService = inputService;
            _player = player;
            _timeService = timeService;
        }

        private void Start()
        {
            legsAnimator = _player.LegsHero.GetComponentInChildren<Animator>();
            _player.MoveHendler.OnMoving += Run;
            
        }


        private void Run()
        {
            legsAnimator.SetBool(Constants.Const.Run, _player.MoveHendler.isMoving);
        }
        
        private void Update()
        {
            legsAnimator.speed = Mathf.Clamp(_timeService.TimeScale, 0.5f, 0.8f);
        }
        private void OnDestroy()
        {
           
            _player.MoveHendler.OnMoving -= Run;
           
        }
    }
}
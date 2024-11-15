using System;
using BsseCode.Audio;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;

namespace BsseCode.Caracters.Hero
{
    public class ActionController : AudioSources
    {
        private IInputService _inputService;
        private Player _player;
        private bool isGo;
        

        [Inject]
        public void Construct(IInputService inputService, Player player)
        {
            _player = player;
            _inputService = inputService;
        }

        private void PlayShoot()
        {
            SoundsExplorer.PlaySoundFrom(SoundStorage.ShootGun, AudioSource());
        }

        private void PlayStep()
        {
            isGo  = _player.MoveHendler.isMoving;
            SoundsExplorer.PlaySoundWhile(SoundStorage.Steps, AudioSource(), isGo);
        }

        private void OnSlow()
        {
            
        }

        // private void Update()
        // {
        //     AudioSource().pitch = Mathf.Clamp(_timeService.TimeScale, 0.9f, 1.0f);
        //     // AudioSource().time = Mathf.Clamp(_timeService.TimeScale, 0.7f, 1.0f);
        //     
        // }

        private void Start()
        {
            _inputService.ShootType1 += PlayShoot;
            _player.MoveHendler.OnMoving += PlayStep;
            _inputService.ToggleTimeEvent += OnSlow;
        }

        private void OnDestroy()
        {
            _inputService.ShootType1 -= PlayShoot;
            _player.MoveHendler.OnMoving -= PlayStep;
            _inputService.ToggleTimeEvent -= OnSlow;
        }
    }
}
using System;
using BsseCode.Audio;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;

namespace BsseCode.Caracters.Hero
{
    public class HeroAudioController : AudioSources
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
            SoundsExplorer.PlayRandomSoundWhile(SoundStorage.Steps1, AudioSource(), _player.MoveHendler.isMoving, pitchMin:  1.3f, pitchMax: 1.6f);
        }

        private void Start()
        {
            _inputService.ShootType1 += PlayShoot;
            _player.MoveHendler.OnMoving += PlayStep;
        }

        private void OnDestroy()
        {
            _inputService.ShootType1 -= PlayShoot;
            _player.MoveHendler.OnMoving -= PlayStep;
        }
        
       
    }
}
using System;
using BsseCode.Audio;
using BsseCode.Pools.Pools;
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
        private IPoolController _poolController;


        [Inject]
        public void Construct(IInputService inputService, Player player, IPoolController poolController)
        {
            _poolController = poolController;
            _player = player;
        }
     
        private void PlayStep()
        {
            var SourceAudio = _poolController.GetPool<SoursSound>().GetElement().GetComponent<AudioSource>();
            SourceAudio.transform.position = _player.transform.position;
            SoundsExplorer.PlayRandomSoundWhile(SoundStorage.Steps1, SourceAudio, _player.MoveHendler.isMoving, pitchMin:  1.3f, pitchMax: 1.6f);
        }

        private void Start()
        {
            _player.MoveHendler.OnMoving += PlayStep;
        }

        private void OnDestroy()
        {
            _player.MoveHendler.OnMoving -= PlayStep;
        }
        
       
    }
}
using System;
using BsseCode.Audio;
using BsseCode.Audio.AudioService;
using BsseCode.Pools.Pools;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;

namespace BsseCode.Caracters.Hero
{
    public class HeroAudioController : MonoBehaviour
    {
        private Player _player;
        private IPoolController _poolController;
        private SoundStorage _soundStorage;
        private IAudioHandler _audioHandler;

        [Inject]
        public void Construct(
            Player player, 
            IPoolController poolController, 
            SoundStorage soundStorage, 
            IAudioHandler audioHandler)
        {
            _audioHandler = audioHandler;
            _soundStorage = soundStorage;
            _poolController = poolController;
            _player = player;
        }
     
        private void PlayStep()
        {
            
            _audioHandler.AudioPlay(_soundStorage.stepsHero, _soundStorage.stepsHeroMixer, _player.transform.position, _poolController);
        }
    }
}
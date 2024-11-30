using System;
using BsseCode.Audio;
using BsseCode.Pools.Pools;
using BsseCode.ScriptablesObjects;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;
using FMOD.Studio;
using UnityEngine.Timeline;

namespace BsseCode.Caracters.Hero
{
    public class HeroAudioController : MonoBehaviour
    {
        private EventInstance playersStepes;
        
        private Player _player;

        private IPoolController _poolController;

        private AudioTracksDate _audioTracksDate;
        private ITimeService _timeControl;

        private void Start()
        {
            
        }

        [Inject]
        public void Construct(
            Player player, IPoolController poolController, AudioTracksDate audioTracksDate, ITimeService timeControl)
        {
            _timeControl = timeControl;
            _audioTracksDate = audioTracksDate;

            _poolController = poolController;
            _player = player;
        }

        private void FixedUpdate()
        {
           
        }

        public void Step()
        {
            
        }

        // private void OnDestroy()
        // {
        //     _player.MoveHendler.OnMoving -= PlayStep;
        // }
    }
}
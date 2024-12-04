using System;
using BsseCode.Audio;
using BsseCode.Audio.AudioSourcesHandlers;
using BsseCode.Caracters.Hero.Components;
using BsseCode.Pools.Pools;
using BsseCode.Pools.Pools.SourceSours;
using BsseCode.Services.InputFol;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace BsseCode.Caracters.Hero
{
    public class HeroAudioController : MonoBehaviour
    {
        private Player _player;
        private AudioTracksBase _audioTracksBase;

        [Inject]
        public void Construct(Player player, AudioTracksBase audioTracksBase )
        {
            _audioTracksBase = audioTracksBase;
            _player = player;
        }

        public void PlayStep()
        {
            AudioManager.Instance.PlaySound(_audioTracksBase.stepEvent, useInstance: false, position: _player.transform.position);
        }
    }
}
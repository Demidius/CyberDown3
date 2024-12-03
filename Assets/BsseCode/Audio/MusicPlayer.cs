using System;
using BsseCode.Audio.AudioSourcesHandlers;
using BsseCode.Caracters.Hero;
using UnityEngine;
using Zenject;

namespace BsseCode.Audio
{
    public class MusicPlayer : MonoBehaviour
    {
        private Player _player;
        private AudioTracksBase _audioTracksBase;

        [Inject]
        public void Construct(
            Player player, AudioTracksBase audioTracksBase
        )
        {
            _audioTracksBase = audioTracksBase;
            _player = player;
        }
        private void Start()
        {
            AudioManager.Instance.PlaySound(_audioTracksBase.music1, useInstance: true, position: _player.transform.position);
        }

        private void OnDestroy()
        {
            AudioManager.Instance.StopSound(_audioTracksBase.music1);
        }

        private void OnDisable()
        {
            AudioManager.Instance.StopSound(_audioTracksBase.music1);
        }
    }
}
           // AudioManager.Instance.PlaySound("event:/Music1", useInstance: false, position: _player.transform.position );
            // AudioManager.Instance.InitializeSoundPool("event:/Music1", 1);

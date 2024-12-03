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
            
            // AudioManager.Instance.InitializeSoundPool("event:/Music1", 1);
            AudioManager.Instance.PlaySound(_audioTracksBase.Music1, useInstance: true, position: _player.transform.position);
           // AudioManager.Instance.PlaySound("event:/Music1", useInstance: false, position: _player.transform.position );
        }
    }
}
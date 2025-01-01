using BsseCode._5._GameEntities.Hero;
using BsseCode._6._Audio.Data;
using BsseCode._6._Audio.Managers;
using UnityEngine;
using Zenject;

namespace BsseCode._6._Audio.UI
{
    public class MusicPlayer : MonoBehaviour
    {
        private Player _player;
        private AudioTracksBase _audioTracksBase;
        private AudioManager _audioManager;

        [Inject]
        public void Construct(
            Player player, AudioTracksBase audioTracksBase, AudioManager audioManager
        )
        {
            _audioManager = audioManager;
            _audioTracksBase = audioTracksBase;
            _player = player;
        }
        private void Start()
        {
            _audioManager.PlaySound(_audioTracksBase.music1, useInstance: true, position: _player.transform.position);
        }

        private void OnDestroy()
        {
            _audioManager.StopSound(_audioTracksBase.music1);
        }

        private void OnDisable()
        {
            _audioManager.StopSound(_audioTracksBase.music1);
        }
    }
}
           // AudioManager.Instance.PlaySound("event:/Music1", useInstance: false, position: _player.transform.position );
            // AudioManager.Instance.InitializeSoundPool("event:/Music1", 1);

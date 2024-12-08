using BsseCode._6._Audio.Data;
using BsseCode._6._Audio.Managers;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Hero
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
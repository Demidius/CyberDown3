using BsseCode._2._Services.GlobalServices.PlayerHandler;
using BsseCode._6._Audio.Data;
using BsseCode._6._Audio.Managers;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Hero
{
    public class HeroAudioController : MonoBehaviour
    {
     
        private AudioTracksBase _audioTracksBase;
        private PlayerHandler _playerHandler;

        [Inject]
        public void Construct(PlayerHandler playerHandler ,AudioTracksBase audioTracksBase )
        {
            _playerHandler = playerHandler;
            _audioTracksBase = audioTracksBase;
        }

        public void PlayStep()
        {
            AudioManager.Instance.PlaySound(_audioTracksBase.stepEvent, useInstance: false, position: _playerHandler.CurrentPlayer.transform.position);
        }
    }
}
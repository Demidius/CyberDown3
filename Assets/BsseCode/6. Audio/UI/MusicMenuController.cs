using BsseCode._6._Audio.Data;
using BsseCode._6._Audio.Managers;
using UnityEngine;
using Zenject;

namespace BsseCode._6._Audio.UI
{
    public class MusicMenuController : MonoBehaviour
    {
       
        private AudioTracksBase _audioTracksBase;

        [Inject]
        public void Construct(
          AudioTracksBase audioTracksBase
        )
        {
            _audioTracksBase = audioTracksBase;
            
        }
        private void Start()
        {
            AudioManager.Instance.PlaySound(_audioTracksBase.musicMenu1, useInstance: true, position: this.transform.position);
        }

        private void OnDestroy()
        {
            AudioManager.Instance.StopSound(_audioTracksBase.musicMenu1);
        }

        private void OnDisable()
        {
            AudioManager.Instance.StopSound(_audioTracksBase.musicMenu1);
        }
    }
}
           // AudioManager.Instance.PlaySound("event:/Music1", useInstance: false, position: _player.transform.position );
            // AudioManager.Instance.InitializeSoundPool("event:/Music1", 1);

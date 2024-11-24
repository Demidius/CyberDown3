using BsseCode.Caracters.Hero;
using BsseCode.Pools.Pools;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace BsseCode.Audio.AudioSourcesHandlers
{
    public class MusicPlayer : MonoBehaviour
    {
        private Player _player;
        private IPoolController _poolController;

        [Inject]
        public void Construct(
            Player player, 
            IPoolController poolController
          )
        {
          
            _poolController = poolController;
            _player = player;
            
        }
        private void Start()
        {
         //  _audioHandler.AudioPlay(_soundStorage.backgroundMusic, _soundStorage.backgroundMixer, _player.transform.position, _poolController);
        }
    }
}
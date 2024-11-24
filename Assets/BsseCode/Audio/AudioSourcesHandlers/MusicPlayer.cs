using BsseCode.Audio.AudioService;
using BsseCode.Caracters.Hero;
using BsseCode.Pools.Pools;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace BsseCode.Audio.AudioSourcesHandlers
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer;
        
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
        private void Start()
        {
           _audioHandler.AudioPlay(_soundStorage.backgroundMusic, _soundStorage.backgroundMixer, _player.transform.position, _poolController);
        }
    }
}
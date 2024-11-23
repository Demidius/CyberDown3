using BsseCode.Pools.Pools;
using BsseCode.Pools.Pools.SourceSours;
using BsseCode.Services.Coroutines;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace BsseCode.Audio.AudioService
{
    public class AudioHandler : IAudioHandler
    {
    
        private Coroutine _activeCoroutine;
        private SourceSound _poolAudioEl;
        private IPoolController _poolController;
        private ICoroutineService _coroutineService;
        
    

        [Inject]
        public void Construct(ICoroutineService coroutineService)
        {
       
            _coroutineService = coroutineService;
        }
  

        public void AudioPlay(AudioClip clip, Vector3 position, IPoolController poolController)
        {
            if (clip == null) 
            {
                Debug.LogWarning("AudioClip is null. Cannot play audio.");
                return;
            }
            BaseRegistration(poolController, position);
            StartAudioReturnRoutine(clip);
        }

        public void AudioPlay(AudioClip[] audioClips, Vector3 position, IPoolController poolController)
        {
            if (audioClips == null || audioClips.Length == 0)
            {
                Debug.LogWarning("AudioClips array is null or empty. Cannot play audio.");
                return;
            }
            BaseRegistration(poolController, position);
            StartAudioReturnRoutine(audioClips);
        }

        private AudioClip RandomClipReg(AudioClip[] audioClips)
        {
            return audioClips[Random.Range(0, audioClips.Length)];
        }

        private void BaseRegistration(IPoolController poolController, Vector3 position)
        {
            _poolController = poolController;
            GetAudioElementFromPool();
            if (_poolAudioEl == null)
            {
                Debug.LogError("poolAudioEl is null. Check the pool or configuration.");
                return;
            }
            _poolAudioEl.transform.position = position;
        }

        private void GetAudioElementFromPool()
        {
            _poolAudioEl = _poolController?.GetPool<SourceSound>()?.GetElement();
            if (_poolAudioEl == null)
            {
                Debug.LogError("SourceSound is null. Check the pool or configuration.");
            }
        }

        private void StartAudioReturnRoutine(AudioClip audioClip)
        {
            _activeCoroutine = _coroutineService?.StartCoroutine(_poolAudioEl.AudioReturnRoutine(audioClip, _activeCoroutine));
        }

        private void StartAudioReturnRoutine(AudioClip[] audioClips)
        {
            StartAudioReturnRoutine(RandomClipReg(audioClips));
        }
    }
}

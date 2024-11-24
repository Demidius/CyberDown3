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
        private ICoroutineService _coroutineService;
        
    

        [Inject]
        public void Construct(ICoroutineService coroutineService)
        {
       
            _coroutineService = coroutineService;
        }
  

        public void AudioPlay(AudioClip clip,  AudioMixerGroup mixerGroup, Vector3 position, IPoolController poolController)
        {
            if (clip == null) 
            {
                Debug.LogWarning("AudioClip is null. Cannot play audio.");
                return;
            }
            BaseRegistration(poolController, position);
            StartAudioReturnRoutine(clip, mixerGroup);
        }

        public void AudioPlay(AudioClip[] audioClips, AudioMixerGroup mixerGroup, Vector3 position, IPoolController poolController)
        {
            if (audioClips == null || audioClips.Length == 0)
            {
                Debug.LogWarning("AudioClips array is null or empty. Cannot play audio.");
                return;
            }
            BaseRegistration(poolController, position);
            StartAudioReturnRoutine(audioClips, mixerGroup);
        }

        private AudioClip RandomClipReg(AudioClip[] audioClips)
        {
            return audioClips[Random.Range(0, audioClips.Length)];
        }

        private void BaseRegistration(IPoolController poolController, Vector3 position)
        {
            GetAudioElementFromPool(poolController);
            if (_poolAudioEl == null)
            {
                Debug.LogError("poolAudioEl is null. Check the pool or configuration.");
                return;
            }
            _poolAudioEl.transform.position = position;
        }

        private void GetAudioElementFromPool(IPoolController poolController)
        {
            _poolAudioEl = poolController?.GetPool<SourceSound>()?.GetElement();
            if (_poolAudioEl == null)
            {
                Debug.LogError("SourceSound is null. Check the pool or configuration.");
            }
        }

        private void StartAudioReturnRoutine(AudioClip audioClip, AudioMixerGroup mixerGroup)
        {
            _activeCoroutine = _coroutineService?.StartCoroutine(_poolAudioEl.AudioReturnRoutine(audioClip, mixerGroup, _activeCoroutine));
        }

        private void StartAudioReturnRoutine(AudioClip[] audioClips, AudioMixerGroup mixerGroup)
        {
            _activeCoroutine = _coroutineService?.StartCoroutine(_poolAudioEl.AudioReturnRoutine(RandomClipReg(audioClips), mixerGroup, _activeCoroutine));
            
        }
    }
}

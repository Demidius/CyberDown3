using System.Collections;
using BsseCode.Pools.Pools;
using BsseCode.Services.AudioService;
using BsseCode.Services.Coroutines;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

public class AudioHandler : IAudioHandler
{
    
    private Coroutine _activeCoroutine;
    private SourceSound poolAudioEl;
    private IPoolController _poolController;
    private ICoroutineService _coroutineService;
    private ITimeService _timeService;

    [Inject]
    public void Construct(ICoroutineService coroutineService, ITimeService timeService)
    {
        _timeService = timeService;
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
        if (poolAudioEl == null)
        {
            Debug.LogError("poolAudioEl is null. Check the pool or configuration.");
            return;
        }
        poolAudioEl.transform.position = position;
    }

    private SourceSound GetAudioElementFromPool()
    {
        poolAudioEl = _poolController?.GetPool<SourceSound>()?.GetElement();
        if (poolAudioEl == null)
        {
            Debug.LogError("SourceSound is null. Check the pool or configuration.");
            return null;
        }
        return poolAudioEl;
    }

    private void StartAudioReturnRoutine(AudioClip audioClip)
    {
        _activeCoroutine = _coroutineService?.StartCoroutine(poolAudioEl.AudioReturnRoutine(audioClip, _activeCoroutine));
    }

    private void StartAudioReturnRoutine(AudioClip[] audioClips)
    {
        StartAudioReturnRoutine(RandomClipReg(audioClips));
    }
   

    private void End()
    {
        poolAudioEl?.Deactivate();
        StopAudioReturnRoutine();
    }

    private void StopAudioReturnRoutine()
    {
        if (_activeCoroutine != null)
        {
            _coroutineService?.StopCoroutine(_activeCoroutine);
            _activeCoroutine = null;
        }
    }
}

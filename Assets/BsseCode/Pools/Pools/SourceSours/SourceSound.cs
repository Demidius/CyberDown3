using System;
using System.Collections;
using BsseCode.Services.Coroutines;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.SourceSours
{
    public class SourceSound : MonoBehaviour, IPoolsElement
    {
        private AudioSource source;

        private IPoolController _poolController;
        private ITimeService _timeService;
        private Coroutine _activeCoroutine;
        private ICoroutineService _coroutineService;

        [Inject]
        public void Construct(IPoolController poolController, ITimeService timeService, ICoroutineService coroutineService)
        {
            _poolController = poolController ?? throw new ArgumentNullException(nameof(poolController));
            _timeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
            _coroutineService = coroutineService ?? throw new ArgumentNullException(nameof(coroutineService));
            source = GetComponent<AudioSource>();
        }

        void Update()
        {
            source.pitch = TimeScaleForAudio();
        }

        public void Deactivate()
        {
            _poolController.ReturnToPool(this);
        }

        public IEnumerator AudioReturnRoutine(AudioClip audioClip, Coroutine activeCoroutine)
        {
            if (audioClip == null)
            {
                Debug.LogError("AudioClip is null. Cannot start AudioReturnRoutine.");
                yield break;
            }

            if (source == null)
            {
                Debug.LogError("AudioSource is null. Ensure the GameObject has an AudioSource component.");
                yield break;
            }

            if (!gameObject.activeInHierarchy)
            {
                Debug.LogError("SourceSound GameObject is inactive. Coroutine cannot run.");
                yield break;
            }

            source.clip = audioClip;
            _activeCoroutine = activeCoroutine;
            source.Play();

            yield return new WaitForSeconds(audioClip.length);
            StopAudioReturnRoutine();
            Deactivate();
        }


        private void StopAudioReturnRoutine()
        {
            if (_activeCoroutine != null)
            {
                _coroutineService?.StopCoroutine(_activeCoroutine);
                _activeCoroutine = null;
            }
        }

        private float TimeScaleForAudio() => Mathf.Clamp(_timeService.TimeScale, 0.6f, 1.0f);
    }
}
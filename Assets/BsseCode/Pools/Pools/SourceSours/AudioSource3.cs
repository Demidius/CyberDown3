using System;
using System.Collections;
using BsseCode.Services.Coroutines;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.SourceSours
{
    public class AudioSource3 : MonoBehaviour, IPoolsElement
    {
        private EventReference _soundEvent;
        private IPoolController _poolController;
        private EventInstance _instance;
        private ICoroutineService _coroutineService;
        
       
        [Inject]
        public void Construct(IPoolController poolController, ICoroutineService coroutineService)
        {
            _coroutineService = coroutineService;
            _poolController = poolController;
        }

        public void SetParameters(EventReference soundEvent, Vector3 position)
        {
            _soundEvent = soundEvent;
            _instance = RuntimeManager.CreateInstance(_soundEvent);

            if (_instance.isValid())
            {
                _instance.set3DAttributes(RuntimeUtils.To3DAttributes(position));
                _instance.start();
                _instance.release();

                float eventLength = GetEventLength(_soundEvent);
                _coroutineService.StartCoroutine(Timer(eventLength));
            }
            else
            {
                Debug.LogError($"Failed to create EventInstance for {_soundEvent.Path}");
            }
        }

        public void Deactivate() => _poolController?.ReturnToPool(this);

        private float GetEventLength(EventReference soundEvent)
        {
            var description = RuntimeManager.GetEventDescription(soundEvent);
            description.getLength(out int length);
            return length / 1000f; // перевод из миллисекунд в секунды
        }

        private IEnumerator Timer(float duration)
        {
            yield return new WaitForSeconds(duration);
            Deactivate();
        }
    }
}
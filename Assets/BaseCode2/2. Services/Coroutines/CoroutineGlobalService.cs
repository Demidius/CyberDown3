using System.Collections;
using UnityEngine;

namespace BaseCode2._2._Services.Coroutines
{
    public class CoroutineGlobalService : ICoroutineGlobalService
    {
        private readonly CoroutineRunner _coroutineRunner;

        public CoroutineGlobalService(CoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public Coroutine StartCoroutine(IEnumerator coroutine) =>
            _coroutineRunner.StartCoroutine(coroutine);

        public void StopCoroutine(Coroutine coroutine)
        {
            if (_coroutineRunner == null)
            {
                Debug.LogWarning("CoroutineRunner is null. Coroutine cannot be stopped.");
                return;
            }

            _coroutineRunner.StopCoroutine(coroutine);
        }
    }
}
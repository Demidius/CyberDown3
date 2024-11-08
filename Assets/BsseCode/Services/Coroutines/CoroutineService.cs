using System.Collections;
using UnityEngine;
using Zenject;

namespace BsseCode.Services.Coroutines
{
    public class CoroutineService : ICoroutineService
    {
        private readonly CoroutineRunner _coroutineRunner;

        [Inject]
        public CoroutineService(CoroutineRunner coroutineRunner) =>
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

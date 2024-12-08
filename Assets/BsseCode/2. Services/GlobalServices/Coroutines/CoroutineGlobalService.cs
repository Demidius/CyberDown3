using System.Collections;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.Coroutines
{
    public class CoroutineGlobalService : ICoroutineGlobalService
    {
        private readonly CoroutineRunner _coroutineRunner;

        [Inject]
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

using System.Collections;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices.Coroutines
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
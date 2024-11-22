using System;
using System.Collections;
using BsseCode.Services.Coroutines;
using UnityEngine;

namespace BsseCode.Pools.Pools.BulletPool
{
    public class BulletLifeCycleManager
    {
        private readonly ICoroutineService _coroutineService;
        private readonly Action _onLifeEnded;
        private Coroutine _lifeRoutine;

        public BulletLifeCycleManager(ICoroutineService coroutineService, Action onLifeEnded)
        {
            _coroutineService = coroutineService;
            _onLifeEnded = onLifeEnded;
        }

        public void StartLifeRoutine(float lifetime)
        {
            StopLifeRoutine();
            _lifeRoutine = _coroutineService?.StartCoroutine(LifeRoutine(lifetime));
        }

        public void StopLifeRoutine()
        {
            if (_lifeRoutine != null)
            {
                _coroutineService?.StopCoroutine(_lifeRoutine);
                _lifeRoutine = null;
            }
        }

        private IEnumerator LifeRoutine(float lifetime)
        {
            yield return new WaitForSeconds(lifetime);
            _onLifeEnded?.Invoke();
        }
    }
}
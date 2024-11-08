using System.Collections;
using UnityEngine;

namespace BsseCode.Services.Coroutines
{
    public interface ICoroutineService : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}

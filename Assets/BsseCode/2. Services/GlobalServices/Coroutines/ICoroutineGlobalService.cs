using System.Collections;
using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.Coroutines
{
    public interface ICoroutineGlobalService : IGlobalService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}

using System.Collections;
using BsseCode._2._Services.GlobalServices;
using UnityEngine;

namespace BaseCode2._2._Services.Coroutines
{
    public interface ICoroutineGlobalService : IGlobalService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}

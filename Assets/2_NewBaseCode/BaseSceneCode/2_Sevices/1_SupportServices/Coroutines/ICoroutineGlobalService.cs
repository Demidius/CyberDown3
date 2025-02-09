using System.Collections;

using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices.Coroutines
{
    public interface ICoroutineGlobalService : IGlobalService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }

    public interface IGlobalService
    {
    }
}

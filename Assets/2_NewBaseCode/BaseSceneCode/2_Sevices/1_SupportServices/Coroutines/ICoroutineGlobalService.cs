using System.Collections;
using BsseCode._2._Services.GlobalServices.Factory;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.Coroutines
{
    public interface ICoroutineGlobalService : IGlobalService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}

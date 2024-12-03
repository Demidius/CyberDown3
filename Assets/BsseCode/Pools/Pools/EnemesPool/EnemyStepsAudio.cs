using BsseCode.Caracters.Hero;
using BsseCode.Pools.Pools.SourceSours;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.EnemesPool
{
    public class EnemyStepsAudio : MonoBehaviour
    {
       
        //
        //
        //
        // [EventRef]
        // public EventReference stepEnemyEvent;
        // private IPoolController _poolController;
        //
        //
        // [Inject]
        // public void Construct(
        //     IPoolController poolController)
        // {
        //     _poolController = poolController;
        // }
        //
        private void PlayStep()
        {
            // var bulletSound = _poolController.GetPool<AudioSource2>().GetElement();
            // bulletSound.SetParameters(stepEnemyEvent, this.transform.position);
        }
    }
}
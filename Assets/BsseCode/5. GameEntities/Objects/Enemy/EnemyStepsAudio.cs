using UnityEngine;

namespace BsseCode._5._GameEntities.Objects.Enemy
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
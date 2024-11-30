using BsseCode.Audio;
using BsseCode.Mechanics.BulletCounter;
using BsseCode.Pools.Pools;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;

namespace BsseCode.Caracters.Hero.Components
{
    public class LegAudioContaner : MonoBehaviour
    {
        private IInputService _inputService;
        private IPoolController _poolController;

        [Inject]
        public void Construct(
            IPoolController poolController,
            IInputService inputService)
        {
            _poolController = poolController;
            _inputService = inputService;
        }

        private void PlayStep()
        {
            // AudioManager.Instance.PlayOneShot(FMODEvents.Instance.playersSteps, this.transform.position);
        }
        
        
    }
}
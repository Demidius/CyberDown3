using BsseCode._2._Services.ServiceLocator;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.PlayerModule
{
    public class AudioStepBech : MonoBehaviour
    {
        private IAudioServicesLocator _audioServicesLocator;

        [Inject]
        public void Construct(
            IAudioServicesLocator audioServicesLocator
        )
        {
            _audioServicesLocator = audioServicesLocator;
        }

        // PlayStep воспроизводится через анимацию
        public void PlayStep()
        {
            _audioServicesLocator.AudioManager.PlaySound(_audioServicesLocator.AudioTracksBase.stepEvent);
        }
    }
}
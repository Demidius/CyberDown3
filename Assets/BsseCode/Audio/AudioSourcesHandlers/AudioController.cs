using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Audio.AudioSourcesHandlers
{
    public class AudioController : MonoBehaviour
    {
        private ITimeService _timeService;

        [Inject]
        public void Construct(ITimeService timeService)
        {
            _timeService = timeService;
        }

        private void Update()
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("TimeController", _timeService.TimeScale);
        }

    }
}
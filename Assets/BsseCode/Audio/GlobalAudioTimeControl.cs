using BsseCode.Caracters.Hero;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Audio
{
    public class GlobalAudioTimeControl : MonoBehaviour
    {
        
        private ITimeService _timeService;
        private Player _player;


        [Inject]
        public void Construct(ITimeService timeService, Player player)
        {
            _player = player;
            _timeService = timeService;
        }
        
        private void Update()
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Global", _timeService.TimeScale);
        }
    }
}
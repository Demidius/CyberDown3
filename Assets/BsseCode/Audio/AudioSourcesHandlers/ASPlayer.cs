using System.Numerics;
using BsseCode.Services.InputFol;
using Zenject;

namespace BsseCode.Audio.AudioSourcesHandlers
{
    public class ASPlayer : AudioSources
    {
        private IInputService _inputService;
        

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _inputService.ShootType1 += PlaySound;
        }

        // private void Update()
        // {
        //     
        //     SoundsExplorer.PlaySoundWhile(SoundStorage.stepsHero, AudioSource(), _inputService.IsGo );
        // }

        private void PlaySound()
        {
            SoundsExplorer.PlaySoundFrom(SoundStorage.ShootGun, AudioSource());
        }

        private void OnDestroy()
        {
            _inputService.ShootType1 -= PlaySound;
        }
    }
}
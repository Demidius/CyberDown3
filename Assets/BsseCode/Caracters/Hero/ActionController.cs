using BsseCode.Audio;
using BsseCode.Services.InputFol;
using Zenject;

namespace BsseCode.Caracters.Hero
{
    public class ActionController : AudioSources
    {
        private IInputService _inputService;
        private Player _player;
        

        [Inject]
        public void Construct(IInputService inputService, Player player)
        {
            _player = player;
            _inputService = inputService;
        }

        private void Start()
        {
            _inputService.ShootType1 += PlayShoot;
            _player.MoveHendler.OnMoving += PlayStep;
        }

    

        private void PlayShoot()
        {
            SoundsExplorer.PlaySoundFrom(SoundStorage.ShootGun, AudioSource());
        }
        
        private void PlayStep(bool isGo)
        {
            SoundsExplorer.PlaySoundWhile(SoundStorage.Steps, AudioSource(), isGo);
        }
        
        

        private void OnDestroy()
        {
            _inputService.ShootType1 -= PlayShoot;
            _player.MoveHendler.OnMoving -= PlayStep;
        }
    }
}
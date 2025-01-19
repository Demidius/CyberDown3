using NewBaseCode._1._GameMachine;
using NewBaseCode._3._UI._1.Controllers;
using NewBaseCode._4._Audio;
using NewBaseCode._4._Audio.Data;
using NewBaseCode._4._Audio.Managers;
using Zenject;

namespace NewBaseCode._0._Installers
{
    public class GameInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterStateMachine();
            RegisterUiControllers();
            RegisterAudioModule();
            
        }

        private void RegisterAudioModule()
        {
            Container.Bind<AudioTracksBase>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IAudioManager>().To<AudioManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IMusicController>().To<MusicController>().FromComponentInHierarchy().AsSingle();
            
            
        }

        private void RegisterUiControllers()
        {
            Container.Bind<IMenuPanelsController>().To<MenuPanelsController>().FromComponentInHierarchy().AsSingle();
            // Container.Bind<IMenuButtonsController>().To<MenuButtonsController>().FromComponentInHierarchy().AsSingle();

        }
            

        private void RegisterStateMachine()
        {
            Container.Bind<IGameMachineModule>().To<GameMachineModule>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}
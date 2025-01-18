using NewBaseCode._1._GameMachine;
using NewBaseCode.UI;
using NewBaseCode.UI._1.Controllers;
using Zenject;

namespace NewBaseCode._0.Installers
{
    public class GameInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterStateMachine();
            RegisterUiControllers();
            
        }

        private void RegisterUiControllers()
        {
            Container.Bind<IMenuPanelsController>().To<MenuPanelsController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IMenuButtonsController>().To<MenuButtonsController>().FromComponentInHierarchy().AsSingle();

        }
            

        private void RegisterStateMachine()
        {
            Container.Bind<IGameMachineModule>().To<GameMachineModule>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}
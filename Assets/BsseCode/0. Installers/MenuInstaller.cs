using BsseCode._1._StateMachines.GameStateMachine;
using Zenject;

namespace BsseCode._0._Installers
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {

            Container.Bind<MenuHandler>().FromComponentInHierarchy().AsSingle();
        }
    }
}
using BsseCode.StateMachines.GameStateMachine;
using Zenject;

namespace BsseCode.Installers
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {

            Container.Bind<MenuHandler>().FromComponentInHierarchy().AsSingle();
        }
    }
}
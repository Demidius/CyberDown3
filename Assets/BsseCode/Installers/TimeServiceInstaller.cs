using BsseCode.Services;
using Zenject;
using BsseCode.Services.TimeProvider;

namespace BsseCode.Installers
{
    public class TimeServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
           Container.Bind<ITimeService>().To<TimeService>().AsSingle();

           Container.Bind<MoveService>().AsTransient();
        }
    }
}
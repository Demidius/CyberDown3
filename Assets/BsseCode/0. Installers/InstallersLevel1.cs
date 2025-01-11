using BsseCode._2._Services.GlobalServices.BeaconHandler;
using BsseCode._2._Services.GlobalServices.PlayerHandlerFl;
using BsseCode._2._Services.LevelServices.BulletCounter;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._2._Services.LevelServices.TimerLevel;
using Zenject;

namespace BsseCode._0._Installers
{
    public class InstallersLevel1 : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterGameManagers();
        }

        private void RegisterGameManagers()
        {
            Container.Bind<BeaconHandler>().FromComponentInHierarchy().AsSingle();
            Container.Bind<KillsController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IEnergyCounter>().To<EnergyCounter>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ResultsManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerHandler>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ITimerLevel>().To<TimerLevel>().AsSingle();
        }
    }
}
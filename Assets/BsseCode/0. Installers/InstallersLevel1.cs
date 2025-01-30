using BsseCode._2._Services.GlobalServices.BeaconHandler;
using BsseCode._2._Services.GlobalServices.Pools;
using BsseCode._2._Services.LevelServices.BulletCounter;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._2._Services.LevelServices.TimerLevel;
using BsseCode._5._GameEntities.UnivercialUtils;
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
          
            Container.Bind<ITimerLevel>().To<TimerLevel>().AsSingle();
            Container.Bind<IPositionUpdateService>().To<PositionUpdateService>().AsSingle();
            Container.Bind<IPoolController>().To<PoolController>().FromComponentInHierarchy().AsSingle();
            
        }
    }
}
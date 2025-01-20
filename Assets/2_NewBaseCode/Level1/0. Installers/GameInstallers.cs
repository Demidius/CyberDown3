using _2_NewBaseCode.BaseSceneCode._2._Sevices.Spawners.PlayerHandlerFl;
using _2_NewBaseCode.Level1._2_Level1Services.Factory;
using _2_NewBaseCode.Level1._2_Level1Services.Pools;
using Zenject;

namespace _2_NewBaseCode.Level1._0._Installers
{
    public class Level1Installers : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            Container.Bind<IFactoryComponent>().To<FactoryComponent>().AsSingle();
            Container.Bind<IPoolController>().To<PoolController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IPlayerHandler>().To<PlayerHandler>().FromComponentInHierarchy().AsSingle();
            
        }
    }
}
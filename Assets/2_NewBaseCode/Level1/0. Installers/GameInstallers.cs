using _2_NewBaseCode.Level1._2_Level1Services.Factory;
using _2_NewBaseCode.Level1._2_Level1Services.Pools;

using _2_NewBaseCode.Level1.Entites._1_Player._1_PlayerHandler;
using _2_NewBaseCode.Level1.Entites._1_Player.Body1;
using NewBaseCode.Level1.Level1Services.SlowMotionTypeControllers;
using Zenject;

namespace _2_NewBaseCode.Level1._0._Installers
{
    public class Level1Installers : MonoInstaller
    {
        
        public override void InstallBindings()
        {
            RegisterServices();
            // Container.Bind<IPlayerBase>().To<PlayerBase>().FromComponentInNewPrefab(basePlayerPrefab).AsSingle();
            // Container.Bind<IPlayersBodyBase>().To<PlayersBodyBase>().FromComponentInNewPrefab(basePlayerPrefab)
            //     .AsSingle();
            // Container.Bind<IPlayersLegsBase>().To<PlayersLegsBase>().FromComponentInNewPrefab(basePlayerPrefab)
            //     .AsSingle();
        }

        private void RegisterServices()
        {
            Container.Bind<IFactoryComponent>().To<FactoryComponent>().AsSingle();
            Container.Bind<IPoolController>().To<PoolController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IPlayerHandler>().To<PlayerHandler>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<IObjectRotation>().To<PlayerBodyRotation>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<ISlowMotionController>().To<SlowMotionController>().FromComponentsInHierarchy().AsSingle();
        }
    }
}


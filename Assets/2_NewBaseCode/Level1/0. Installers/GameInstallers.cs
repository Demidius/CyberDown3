using _2_NewBaseCode.Level1._1_Level1Controllers;
using _2_NewBaseCode.Level1._2_Level1Services.Pools;
using _2_NewBaseCode.Level1.Entites._1_Player._1_PlayerHandler;
using _2_NewBaseCode.Level1.Entites._1_Player.Body1;
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
          
            Container.Bind<IPoolController>().To<PoolController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IPlayerHandler>().To<PlayerHandler>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<IObjectRotation>().To<PlayerBodyRotation>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<ISlowMotionController>().To<SlowMotionController>().FromComponentsInHierarchy().AsSingle();
            

        }
    }
}


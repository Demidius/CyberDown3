using BsseCode._2._Services.GlobalServices.Factory;
using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.Pools;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices.BulletCounter;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._2._Services.LevelServices.TimerLevel;
using BsseCode._3._SupportCode.PlayerMouseService;
using BsseCode._5._GameEntities.Hero;
using BsseCode._5._GameEntities.UnivercialUtils;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace BsseCode._0._Installers
{
    public class GameStartInstaller : MonoInstaller
    {
      [SerializeField] private GameObject playerPrefab;
        
        public override void InstallBindings()
        {
            #region Services

            Container.Bind<IInputGlobalService>().To<PcInputGlobalService>().AsSingle();
            Container.Bind<IPlayerMouseService>().To<PlayerMouseGlobalService>().AsSingle();
           
            Container.Bind<PositionUpdateService>().AsSingle();
            Container.Bind<KillsController>().FromComponentInHierarchy().AsSingle();

            #endregion

            #region Mechanics

            Container.Bind<IEnergyCounter>().To<EnergyCounter>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ITimerLevel>().To<TimerLevel>().AsSingle();
         
            //Container.Bind<ResultsManager>().FromComponentInHierarchy().AsSingle();

            #endregion


            #region Camera

            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CinemachineVirtualCamera>().FromComponentInHierarchy().AsSingle();

            #endregion

            
            Container.Bind<IFactoryComponent>().To<FactoryComponent>().AsSingle();
            
            Container.Bind<Player>().FromComponentInNewPrefab(playerPrefab).AsSingle();
            
            Container.Bind<IPoolController>().To<PoolController>().FromComponentInHierarchy().AsSingle();
            
            Container.Bind<TimeController>().FromComponentInHierarchy().AsSingle();
            
              
            
        }
    }
}
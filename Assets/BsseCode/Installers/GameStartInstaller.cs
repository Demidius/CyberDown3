using BsseCode.Caracters.Hero;
using BsseCode.Mechanics.BulletCounter;
using BsseCode.Mechanics.GameResults;
using BsseCode.Mechanics.TimerLevel;
using BsseCode.Pools.Pools;
using BsseCode.Services;
using BsseCode.Services.Factory;
using BsseCode.Services.InputFol;
using BsseCode.Services.PlayerMouseService;
using BsseCode.Services.TimeProvider;
using Cinemachine;
using UnityEngine;
using Zenject;


namespace BsseCode.Installers
{
    public class GameStartInstaller : MonoInstaller
    {
        [SerializeField] private GameObject poolsBasePrefab;
        [SerializeField] private GameObject poolBasePrefab;
        [SerializeField] private GameObject playerPrefab;
        
        public override void InstallBindings()
        {
            #region Services

            Container.Bind<IInputService>().To<PcInputService>().AsSingle();
            Container.Bind<IPlayerMouseService>().To<PlayerMouseService>().AsSingle();
           
            Container.Bind<MoveService>().AsSingle();
            Container.Bind<KillsController>().FromComponentInHierarchy().AsSingle();

            #endregion

            #region Mechanics

            Container.Bind<IBulletCounter>().To<BulletCounter>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ITimerLevel>().To<TimerLevel>().AsSingle();
          //  Container.Bind<SpawnZonaController>().FromComponentInHierarchy().AsSingle();
            
            //Container.Bind<ResultsManager>().FromComponentInHierarchy().AsSingle();

            #endregion


            #region Camera

            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CinemachineVirtualCamera>().FromComponentInHierarchy().AsSingle();

            #endregion

            // Container.Bind<PlayerFactory>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IFactoryComponent>().To<FactoryComponent>().AsSingle();

            Container.Bind<IPoolsBase>().To<PoolsController>().FromComponentInNewPrefab(poolsBasePrefab).AsSingle();
            Container.Bind<IPoolController>().To<PoolController>().FromComponentInNewPrefab(poolBasePrefab).AsSingle();
            
            Container.Bind<Player>().FromComponentInNewPrefab(playerPrefab).AsSingle();
            
            
            
              
            
        }
    }
}
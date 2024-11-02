using BsseCode.GameStateMachineFolder;
using BsseCode.Services.Factory;
using BsseCode.Services.Input;
using BsseCode.Services.PlayerMouseService;
using UnityEngine;
using Zenject;

namespace BsseCode.Installers
{
    public class GameStartInstaller : MonoInstaller
    {
      
        public override void InstallBindings()
        {
            #region Services
            Container.Bind<IInputService>().To<PcInputService>().AsSingle();
            Container.Bind<IPlayerMouseService>().To<PlayerMouseService>().AsSingle();
            
          
           
            #endregion

            #region StateMachine
            Container.Bind<GameStateMachine>().AsSingle().NonLazy();

            #endregion
        }
    }
}
using BsseCode.GameStateMachineFolder;
using BsseCode.Services.Input;
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
           
            #endregion

            #region StateMachine
            Container.Bind<GameStateMachine>().AsSingle().NonLazy();

            #endregion
        }
    }
}
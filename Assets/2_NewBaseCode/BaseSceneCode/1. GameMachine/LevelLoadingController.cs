using _2_NewBaseCode.BaseSceneCode._2._Sevices.Addressable.NewBaseCode._2._Services.Addressable;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._1._GameMachine
{
    public class LevelLoadingController : MonoBehaviour, ILevelLoadingController
    {
        private IGameMachineModule _gameMachineModule;
        private IAddressableLoader _addressableLoader;

        [Inject]
        void Construct(IGameMachineModule gameMachineModule, IAddressableLoader addressableLoader)
        {
            _addressableLoader = addressableLoader;
            _gameMachineModule = gameMachineModule;
        }

        public void StartFirstLevel()
        {
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.LoadState);
            _addressableLoader.LoadLevelByIndex(0);
        }
    }

    public interface ILevelLoadingController
    {
        public void StartFirstLevel();
    }
}
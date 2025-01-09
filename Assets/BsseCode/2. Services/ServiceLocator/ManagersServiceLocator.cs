using BsseCode._2._Services.GlobalServices.BeaconHandler;
using BsseCode._2._Services.GlobalServices.PlayerHandlerFl;
using BsseCode._2._Services.LevelServices.GameResults;
using Zenject;

namespace BsseCode._2._Services.ServiceLocator
{
    public class ManagersServiceLocator : IManagersServiceLocator

    {
        public BeaconHandler BeaconHandler { get; private set; }
        public KillsController KillsController { get; private set; }
        public ResultsManager ResultsManager { get; private set; }
        public PlayerHandler PlayerHandler { get; private set; }

        [Inject]
        void Construct(
            PlayerHandler playerHandler,
            ResultsManager resultsManager,
            KillsController killsController,
            BeaconHandler beaconHandler
        )
        {
            BeaconHandler = beaconHandler;
            KillsController = killsController;
            ResultsManager = resultsManager;
            PlayerHandler = playerHandler;
        }
    }

    public interface IManagersServiceLocator
    {
        public PlayerHandler PlayerHandler { get; }
        public ResultsManager ResultsManager { get; }
        public KillsController KillsController { get; }
        public BeaconHandler BeaconHandler { get; }


    }
}
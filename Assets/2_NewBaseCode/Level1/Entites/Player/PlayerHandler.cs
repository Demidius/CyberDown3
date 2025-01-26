using _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler;
using _2_NewBaseCode.BaseSceneCode.PlayerPrefabManeger;
using _2_NewBaseCode.Level1._2_Level1Services.Factory;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1.Entites.Player
{
    public class PlayerHandler : MonoBehaviour, IPlayerHandler
    {
        private IFactoryComponent _factoryComponent;
        private IPlayerPrefabsDate _playerPrefabsDate;

        private PlayerComponent _currentPlayerBase;
        private PlayerComponent _currentBody;
        private PlayerComponent _currentLegs;
        private ICameraHandler _playerCameraHandler;

        [Inject]
        void Construct(
            IPlayerPrefabsDate playerPrefabsDate,
            IFactoryComponent factoryComponent,
            ICameraHandler playerCameraHandler
        )
        {
            _playerCameraHandler = playerCameraHandler;
            _playerPrefabsDate = playerPrefabsDate;
            _factoryComponent = factoryComponent;
        }

        private void Start()
        {
            CreatePlayer();
        }

        public void CreatePlayer()
        {
            _currentPlayerBase = _factoryComponent.Create(_playerPrefabsDate.GetCurrentPlayerBase());
            
            _currentBody = _factoryComponent.Create(_playerPrefabsDate.GetCurrentPlayerBody());
            _currentBody.transform.SetParent(_currentPlayerBase.transform);
            
            _currentLegs = _factoryComponent.Create(_playerPrefabsDate.GetCurrentPlayerLegs());
            _currentLegs.transform.SetParent(_currentPlayerBase.transform);

            RegistrationPlayer();
        }

        public Vector3 GetPlayerPosition()
        {
            return _currentPlayerBase.transform.position;
        }

        private void RegistrationPlayer()
        {
        }
    }

    public interface IPlayerHandler
    {
        void CreatePlayer();
        Vector3 GetPlayerPosition();
    }
}
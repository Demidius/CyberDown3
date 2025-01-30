using _2_NewBaseCode.BaseSceneCode.PlayerPrefabManeger;
using _2_NewBaseCode.Level1._2_Level1Services.Factory;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1.Entites._1_Player._1_PlayerHandler
{
    public class PlayerHandler : MonoBehaviour, IPlayerHandler
    {
        private IFactoryComponent _factoryComponent;
        private IPlayerPrefabsDate _playerPrefabsDate;

        private PlayerComponent _currentPlayerBase;
        private PlayerComponent _currentBody;
        private PlayerComponent _currentLegs;
     

        [Inject]
        void Construct(
            IPlayerPrefabsDate playerPrefabsDate,
            IFactoryComponent factoryComponent
        )
        {
            _playerPrefabsDate = playerPrefabsDate;
            _factoryComponent = factoryComponent;
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

        public Transform GetPlayerPosition()
        {
            return _currentPlayerBase.transform;
        }

        private void RegistrationPlayer()
        {
        }
    }

    public interface IPlayerHandler
    {
        void CreatePlayer();
        Transform GetPlayerPosition();
    }
}
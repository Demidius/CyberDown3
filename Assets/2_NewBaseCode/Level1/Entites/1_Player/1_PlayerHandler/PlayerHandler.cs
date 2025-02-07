using _2_NewBaseCode.BaseSceneCode.PlayerPrefabManeger;
using _2_NewBaseCode.Level1._2_Level1Services.Factory;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1.Entites._1_Player._1_PlayerHandler
{
    public class PlayerHandler : MonoBehaviour, IPlayerHandler
    {
        private IFactory1 _factory1;
        private IPlayerPrefabsDate _playerPrefabsDate;

        private PlayerComponent _currentPlayerBase;
        private PlayerComponent _currentBody;
        private PlayerComponent _currentLegs;
     

        [Inject]
        void Construct(
            IPlayerPrefabsDate playerPrefabsDate,
            IFactory1 factory1
        )
        {
            _playerPrefabsDate = playerPrefabsDate;
            _factory1 = factory1;
        }
       
        public void CreatePlayer()
        {
            _currentPlayerBase = _factory1.Create(_playerPrefabsDate.GetCurrentPlayerBase());
            
            _currentBody = _factory1.Create(_playerPrefabsDate.GetCurrentPlayerBody());
            _currentBody.transform.SetParent(_currentPlayerBase.transform);
            
            _currentLegs = _factory1.Create(_playerPrefabsDate.GetCurrentPlayerLegs());
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
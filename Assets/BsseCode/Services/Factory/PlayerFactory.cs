using BsseCode.Hero;
using Cinemachine;
using Zenject;
using UnityEngine;

namespace BsseCode.Services.Factory
{
    public class PlayerFactory
    {
        private readonly DiContainer _container;
        private readonly GameObject _playerPrefab;
        private Camera _mainCamera;
        private CinemachineVirtualCamera _virtualCamera;

        public Player Player {get; private set;}
        
        public PlayerFactory(DiContainer container, GameObject playerPrefab)
        {
            _container = container;
            _playerPrefab = playerPrefab;
        }

        [Inject]
        public void Construct(CinemachineVirtualCamera virtualCamera)
        {
            _virtualCamera = virtualCamera;
        }
        
        public Player Create(Vector2 position)
        {
            Player = _container.InstantiatePrefabForComponent<Player>(_playerPrefab, position, Quaternion.identity, null  );
            _virtualCamera.Follow = Player.transform;
            return Player;
            
        }
    }
}
using BsseCode.Hero;
using Zenject;
using UnityEngine;

namespace BsseCode.Services.Factory
{
    public class PlayerFactory
    {
        private readonly DiContainer _container;
        private readonly GameObject _playerPrefab;

        public PlayerFactory(DiContainer container, GameObject playerPrefab)
        {
            _container = container;
            _playerPrefab = playerPrefab;
        }

        public Player Create(Vector2 position)
        {
            var playerInstance = _container.InstantiatePrefabForComponent<Player>(_playerPrefab, position, Quaternion.identity, null);
            return playerInstance;
        }
    }
}
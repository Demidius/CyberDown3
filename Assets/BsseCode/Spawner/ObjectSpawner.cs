using BsseCode.Services.Factory;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace BsseCode.Spawner
{
    public class ObjectSpawner : MonoBehaviour
    {
        private PlayerFactory _playerFactory;

        [Inject]
        public void Construct(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        private void Start()
        {
            SpawnPlayer(Vector2.zero);
        }
        
        
        public void SpawnPlayer(Vector2 position)
        {
            _playerFactory.Create(position);
        }
    }
}
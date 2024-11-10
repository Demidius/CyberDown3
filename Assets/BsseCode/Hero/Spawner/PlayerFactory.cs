using BsseCode.StateMachines.GameStateMachine.States;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace BsseCode.Hero.Spawner
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        
        private Camera _mainCamera;
        private CinemachineVirtualCamera _virtualCamera;

        public Player Player { get; private set; }

        
        [Inject]
        private DiContainer _container;

        private GameplayState _gameplayState;

        [Inject]
        public void Construct(CinemachineVirtualCamera virtualCamera, GameplayState gameplayState)
        {
            _gameplayState = gameplayState;
            _virtualCamera = virtualCamera;
            Create(Vector2.zero); 
        }

        public Player Create(Vector2 position)
        {
            Player = _container.InstantiatePrefabForComponent<Player>(playerPrefab, position, Quaternion.identity,
                null);
            _virtualCamera.Follow = Player.transform;
            return Player;
        }
    }
}
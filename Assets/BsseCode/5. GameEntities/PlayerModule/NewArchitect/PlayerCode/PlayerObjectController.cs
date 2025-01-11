using BsseCode._2._Services.ServiceLocator;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.PlayerModule.NewArchitect.PlayerCode
{
    public class PlayerObjectController : IPlayerObjectController
    {
        private IReusableServiceLocator _serviceLocator;
        private ICameraServiceLocator _cameraServiceLocator;

        [Inject]
        void Construct(
            IReusableServiceLocator serviceLocator,
            ICameraServiceLocator cameraServiceLocator
        )
        {
            _cameraServiceLocator = cameraServiceLocator;
            _serviceLocator = serviceLocator;
        }

        public void CreatePlayer(Player currentPlayer, Player playerPrefab)
        {
            if (currentPlayer == null)
            {
                currentPlayer = _serviceLocator.FactoryComponent.Create(playerPrefab);
            }

            if (!currentPlayer.GameObject().activeSelf)
            {
                ActivatePlayer(currentPlayer);
            }
        }

        public void DestroyPlayer(Player currentPlayer)
        {
            if (currentPlayer != null)
            {
                currentPlayer.GameObject().SetActive(false);
            }
        }

        private void ActivatePlayer(Player currentPlayer)
        {
            var playerObject = currentPlayer.GameObject();

            if (playerObject != null)
            {
                playerObject.SetActive(true);
                playerObject.transform.position = Vector3.zero;
                _cameraServiceLocator.CinemachineVirtualCamera.Follow = currentPlayer.transform;
            }
            else
            {
                Debug.LogError("Player GameObject is null!");
            }
        }
    }

    public interface IPlayerObjectController
    {
        public void CreatePlayer(Player currentPlayer, Player playerPrefab);
        public void DestroyPlayer(Player currentPlayer);
    }
}
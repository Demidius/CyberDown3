using System.Collections.Generic;
using BsseCode._2._Services.GlobalServices.Factory;
using BsseCode._5._GameEntities.Hero;
using BsseCode._5._GameEntities.Objects.Enemy;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.PlayerHandlerFl
{
    public class PlayerHandler : MonoBehaviour
    {
        [SerializeField] private Player playerPrefs;
        private float spawnColliderRadius = 3f;

        private IFactoryComponent _factoryComponent;
        private CinemachineVirtualCamera _vcam;

        public Player CurrentPlayer { get; private set; }

        [Inject]
        public void Construct(IFactoryComponent factoryComponent, CinemachineVirtualCamera vcam)
        {
            _factoryComponent = factoryComponent ?? throw new System.ArgumentNullException(nameof(factoryComponent));
            _vcam = vcam ?? throw new System.ArgumentNullException(nameof(vcam));
        }


        public void CreatePlayer()
        {
            if (CurrentPlayer == null)
            {
                CurrentPlayer = _factoryComponent.Create(playerPrefs);
            }

            if (!CurrentPlayer.GameObject().activeSelf)
            {
                ActivatePlayer();
            }

            CheckAndDeactivateEnemiesAroundPlayer();

        }

        public void DestroyPlayer()
        {
            if (CurrentPlayer != null)
            {
                CurrentPlayer.GameObject().SetActive(false);
            }
        }

        private void ActivatePlayer()
        {
            var playerObject = CurrentPlayer.GameObject();

            if (playerObject != null)
            {
                playerObject.SetActive(true);
                playerObject.transform.position = Vector3.zero;
                _vcam.Follow = CurrentPlayer.transform;
            }
            else
            {
                Debug.LogError("Player GameObject is null!");
            }
        }

        public void CheckAndDeactivateEnemiesAroundPlayer()
        {
            if (CurrentPlayer == null) return;

            var playerPosition = CurrentPlayer.transform.position;
            var colliders = Physics2D.OverlapCircleAll(playerPosition, spawnColliderRadius);

            List<GameObject> enemiesToDeactivate = new List<GameObject>();

            foreach (var collider in colliders)
            {
                var enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemiesToDeactivate.Add(enemy.gameObject);
                    Debug.Log("Enemy detected");
                }
            }

            foreach (var enemyObject in enemiesToDeactivate)
            {
                var enemyComponent = enemyObject.GetComponent<Enemy>();
                enemyComponent?.ReturnToPool();
            }




        }
    }
}

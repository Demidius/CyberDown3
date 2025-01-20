using System.Collections.Generic;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler;
using _2_NewBaseCode.BaseSceneCode.Entites.Enemy;
using _2_NewBaseCode.BaseSceneCode.Entites.Hero;
using _2_NewBaseCode.Level1._2_Level1Services.Factory;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices.Spawners.PlayerHandlerFl
{
    public class PlayerHandler : MonoBehaviour, IPlayerHandler
    {
        [SerializeField] private Player playerPrefs;
        private float spawnColliderRadius = 3f;

        private IFactoryComponent _factoryComponent;
        private ICameraHandler _vcam;


        public Player CurrentPlayer { get; private set; }

        [Inject]
        public void Construct(IFactoryComponent factoryComponent, ICameraHandler vcam)
        {
            _vcam = vcam;
            _factoryComponent = factoryComponent ?? throw new System.ArgumentNullException(nameof(factoryComponent));
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

            // CheckAndDeactivateEnemiesAroundPlayer();
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
                _vcam.Follow(CurrentPlayer.GameObject());
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
                var enemyComponent = enemyObject.GetComponent<IEnemy>();
                enemyComponent?.Kill();
            }
        }
    }

    public interface IPlayerHandler
    {
        void CreatePlayer();
        void DestroyPlayer();
        void CheckAndDeactivateEnemiesAroundPlayer();
    }
}
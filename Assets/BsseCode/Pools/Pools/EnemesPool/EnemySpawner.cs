using System.Collections;
using System.Collections.Generic;
using BsseCode.Caracters.Hero;
using BsseCode.Constants;
using BsseCode.Pools.Pools.ExplosionPool;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.EnemesPool
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<Collider2D> spawnAreas;
        [SerializeField] private float spawnInterval = 2f;
        [SerializeField] private float minDistansForEnemy;


        private float _speedEnemy = Const.SpeedEnemy;
        private Collider2D _randomCollider;
        private IPoolController _poolController;
        private float _timer = 0f;
        private ITimeService _timeService;
        private IExplosionSpawner _explosionSpawner;
        private Player _player;


        [Inject]
        public void Construct(IPoolController poolController, ITimeService timeService, Player player)
        {
            _player = player;
            _timeService = timeService;
            _poolController = poolController;
        }

        private void Start()
        {
            StartCoroutine(SpawnObjects());
            StartCoroutine(ReduceSpawnIntervalOverTime());
        }

        private IEnumerator SpawnObjects()
        {
            while (true)
            {
                _timer += _timeService.DeltaTime;

                if (_timer >= spawnInterval)
                {
                    SpawnObjectInCollider();
                    _timer = 0f;
                }

                yield return new WaitForSeconds(_timeService.DeltaTime);
            }
        }

        private IEnumerator ReduceSpawnIntervalOverTime()
        {
            while (spawnInterval > 0.5f)
            {
                if (spawnInterval > 0.9f)
                    spawnInterval -= 0.1f;
                else if (spawnInterval > 0.5f)
                    spawnInterval -= 0.01f;

                spawnInterval = Mathf.Max(spawnInterval, 0.5f);
                yield return new WaitForSeconds(1f); // Уменьшать интервал раз в секунду
            }
        }

        private void SpawnObjectInCollider()
        {
            if (spawnAreas.Count == 0) return;

            Vector3 randomPosition;

            Collider2D selectedCollider;
            do
            {
                selectedCollider = spawnAreas[Random.Range(0, spawnAreas.Count)];
                randomPosition = GetRandomPointInCollider(selectedCollider);
            } while (Vector3.Distance(randomPosition, _player.transform.position) < minDistansForEnemy);

            var enemy = _poolController.GetPool<Enemy>().GetElement();;
            enemy.transform.position = randomPosition;
            enemy.SetParameters(_speedEnemy);
        }

        private Vector3 GetRandomPointInCollider(Collider2D collider)
        {
            Vector3 point;
            int maxAttempts = 10;

            for (int i = 0; i < maxAttempts; i++)
            {
                point = new Vector3(
                    Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                    Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                    0
                );

                if (collider.bounds.Contains(point))
                {
                    return point;
                }
            }

            return collider.bounds.center;
        }
    }
}
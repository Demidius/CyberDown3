using System.Collections;
using System.Collections.Generic;
using BsseCode.Pools.Pools.ExplosionPool;
using BsseCode.Services;
using BsseCode.Services.Coroutines;
using BsseCode.Services.Factory;
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
        [SerializeField] private float _speedEnemy = 1;
      


        private Collider2D _randomCollider;
        private IPoolsBase _poolBase;
        private float _timer = 0f;
        private ITimeService _timeService;
        private MoveService _moveService;
        private PlayerFactory _playerFactory;
        private IExplosionSpawner _explosionSpawner;
        private ICoroutineService _coroutineService;

        [Inject]
        public void Construct(IPoolsBase poolBase, PlayerFactory playerFactory, ITimeService timeService, MoveService moveService, ICoroutineService coroutineService)
        {
            _coroutineService = coroutineService;
            _playerFactory = playerFactory;
            _moveService = moveService;
            _timeService = timeService;
            _poolBase = poolBase;
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
                } while (Vector3.Distance(randomPosition, _playerFactory.Player.transform.position) < minDistansForEnemy);

                var enemy = _poolBase.EnemyPoolComponent.GetElement();
                enemy.transform.position = randomPosition;
                enemy.SetParameters(_speedEnemy, _playerFactory.Player, _poolBase, _moveService, _coroutineService);
               
            
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
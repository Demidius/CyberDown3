using System.Collections;
using System.Collections.Generic;
using BsseCode.Hero;
using BsseCode.Services;
using BsseCode.Services.Factory;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;


namespace BsseCode.Enemes
{
    public class SpaunerEnemy1 : MonoBehaviour
    {
        //[SerializeField] private Transform _bulletSpawnPoint;

        //private float _enemySpeed = 10;

        [SerializeField] private List<Collider2D> spawnAreas;
        [SerializeField] private float spawnInterval = 2f;
        [SerializeField] private float minDistansForEnemy;
        [SerializeField] private float _speedEnemy = 1;


        private Collider2D _randomCollider;
        private IPoolEnemy1 _poolEnemy1;
        private float _timer = 0f;
        private ITimeService _timeService;
      //  private Player _player;
        private MoveService _moveService;
        private PlayerFactory _playerFactory;

        [Inject]
        public void Construct(IPoolEnemy1 poolEnemy1, PlayerFactory playerFactory, ITimeService timeService, MoveService moveService)
        {
            _playerFactory = playerFactory;
            _moveService = moveService;
            _timeService = timeService;
            _poolEnemy1 = poolEnemy1;
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
                    Debug.Log("Spawning objects");
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
           
                Debug.Log("Spawning object");
                Collider2D selectedCollider;
                do
                {
                    Debug.Log("1");
                    selectedCollider = spawnAreas[Random.Range(0, spawnAreas.Count)];
                    randomPosition = GetRandomPointInCollider(selectedCollider);
                } while (Vector3.Distance(randomPosition, _playerFactory._playerInstance.transform.position) < minDistansForEnemy);

                var enemy = _poolEnemy1.GetEnemy();
                Debug.Log("2");
                enemy.transform.position = randomPosition;
                enemy.SetParameters(_speedEnemy, _playerFactory._playerInstance, _poolEnemy1, _moveService);
                Debug.Log("Spawning objects");
            
        }

        private Vector3 GetRandomPointInCollider(Collider2D collider)
        {
            Vector3 point;
            int maxAttempts = 10; // Ограничиваем количество попыток

            for (int i = 0; i < maxAttempts; i++)
            {
                point = new Vector3(
                    Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                    Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                    0 // Если работаешь в 2D, z=0
                );

                if (collider.bounds.Contains(point))
                {
                    return point;
                }
            }

            // Если не удалось найти подходящую точку, возвращаем центр коллайдера
            return collider.bounds.center;
        }
      
    }
}
using System.Collections;
using BsseCode.Services;
using BsseCode.Services.Coroutines;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.BulletPool
{
    public class Bullet : MonoBehaviour, IPoolsElement
    {
        [SerializeField] private float lifetime = 2f;

        private IPoolController _poolComponent;
        private float _speed;
        private MoveService _moveService;
        private Vector2 _direction;
        private ICoroutineService _coroutineService;
        private Coroutine _coroutineLifeRoutine;

        [Inject]
        public void Construct(MoveService moveService, IPoolController poolBullet, ICoroutineService coroutineService)
        {
            _coroutineService = coroutineService;
            _moveService = moveService;
            _poolComponent = poolBullet;
        }

        public void SetParameters(float speed, Vector2 direction)
        {
            _speed = speed;
            _direction = direction.normalized;

            SetRotationBasedOnDirection();
            StartLifeRoutine();
        }

        private void SetRotationBasedOnDirection()
        {
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void Update()
        {
            MoveBullet();
        }

        private void MoveBullet()
        {
            Vector3 newPosition = _moveService.Move(_direction, _speed, transform.position);
            transform.position = newPosition;
        }

        private void OnDisable()
        {
            StopLifeRoutine();
        }

        private void StartLifeRoutine()
        {
            StopLifeRoutine(); // Остановить корутину, если она уже запущена
            _coroutineLifeRoutine = _coroutineService.StartCoroutine(LifeRoutine());
        }

        private void StopLifeRoutine()
        {
            if (_coroutineLifeRoutine != null)
            {
                _coroutineService.StopCoroutine(_coroutineLifeRoutine);
                _coroutineLifeRoutine = null;
            }
        }

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSeconds(lifetime);
            Deactivate();
        }

        public void Deactivate()
        {
            var bulletPool = _poolComponent.GetPool<Bullet>();
            if (bulletPool != null)
            {
                bulletPool.ReturnToPool(this);
            }
            else
            {
                Debug.LogWarning("Bullet pool is not found.");
            }
        }
    }
}

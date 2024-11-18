using BsseCode.Mechanics.BulletCounter;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.BulletPool
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _bulletSpawnPoint;

        private readonly float _bulletSpeed = 10;
        private IPoolController _poolBullet;
        private Vector2 _direction;
        private IInputService _inputService;
       
        private IBulletCounter _bulletCounter;

        [Inject]
        public void Construct(IPoolController poolController, IInputService inputService, IBulletCounter bulletCounter)
        {
            _bulletCounter = bulletCounter;
            _poolBullet = poolController;
            _inputService = inputService;
        }

        private void Start()
        {
            _inputService.ShootType1 += Shoot;
        }

        private void Update()
        {
            _direction = this.transform.up;
        }

        private void Shoot()
        {
            if (_bulletCounter.BulletCount > 0)
            {
                // Получаем пул через метод GetPool
                var bulletPool = _poolBullet.GetPool<Bullet>();

                if (bulletPool != null)
                {
                    // Извлекаем пулю из пула
                    var bullet = bulletPool.GetElement();
                    bullet.transform.position = _bulletSpawnPoint.position;
                    bullet.SetParameters(_bulletSpeed, _direction);
                    _bulletCounter.SubtractBullet();
                }
                else
                {
                    Debug.LogError("Bullet pool not found!");
                }
            }
            else
            {
                Debug.Log("Gun is empty");
            }
        }
    }
}
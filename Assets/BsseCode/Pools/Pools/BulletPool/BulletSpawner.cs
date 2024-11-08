using BsseCode.Mechanics;
using BsseCode.Mechanics.BulletCounter;
using BsseCode.Pools.Weapons;
using BsseCode.Services.Coroutines;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.BulletPool
{
    public class BulletSpawner : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform _bulletSpawnPoint;

        private readonly float _bulletSpeed = 10;
        private IPoolsBase _poolBullet;
        private Vector2 _direction;
        private IInputService _inputService;
        private ICoroutineService _coroutineService;
        private IBulletCounter _bulletCounter;

        [Inject]
        public void Construct(IPoolsBase poolBullet, IInputService inputService, ICoroutineService coroutineService, IBulletCounter bulletCounter)
        {
            _bulletCounter = bulletCounter;
            _coroutineService = coroutineService;
            _poolBullet = poolBullet;
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
            var bullet = _poolBullet.BulletPoolComponent.GetElement();
            bullet.transform.position = _bulletSpawnPoint.transform.position;
            bullet.SetParameters(_bulletSpeed, _direction ,_poolBullet, _coroutineService);
            _bulletCounter.SubtractBullet();
            Debug.Log("Bullet Count: " + _bulletCounter.BulletCount);
            }
            else
            {
                Debug.Log("Gun is empty");
            }
            
        }
    }
}
using BsseCode.Pools.Pools;
using BsseCode.Pools.Weapons.Bullet;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Weapons
{
    public class Gunner : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform _bulletSpawnPoint;

        private float _bulletSpeed = 10;
        private IPoolsBase _poolBullet;
        private Vector2 direction;
        private IInputService _inputService;

        [Inject]
        public void Construct(IPoolsBase poolBullet, IInputService inputService)
        {
            _poolBullet = poolBullet;
            _inputService = inputService;
        }

        private void Start()
        {
            _inputService.ShootType1 += Shoot;
        }

        private void Update()
        {
            _inputService.Shoot();
            direction = this.transform.up;
        }

        private void Shoot()
        {
            var bullet = _poolBullet.BulletPoolComponent.GetElement();
            bullet.transform.position = _bulletSpawnPoint.transform.position;
            bullet.SetParameters(_bulletSpeed, direction ,_poolBullet);
        }
    }
}
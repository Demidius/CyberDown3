using BsseCode.Hero.Spawner;
using BsseCode.Services.Factory;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ShootFiresPool
{
    public class ShootFireSpawner : MonoBehaviour
    {
        private Transform _spawnPoint;
        
        private IPoolsBase _poolBase;
        private Vector2 _direction;
        private IInputService _inputService;
        private PlayerFactory _playerFactory;

        [Inject]
        public void Construct(IPoolsBase poolBullet, IInputService inputService, PlayerFactory playerFactory )
        {
            _playerFactory = playerFactory;
            _poolBase = poolBullet;
            _inputService = inputService;
        }

        private void Start()
        {
            _inputService.ShootType1 += Shoot;
            _spawnPoint = _playerFactory.Player.ShootStarter.transform;
        }

        private void Update()
        {
            _inputService.Shoot();
            _direction = _spawnPoint.up ;
        }

        private void Shoot()
        {
            var element = _poolBase.ShootFirePoolComponent.GetElement();
            element.transform.position = _spawnPoint.transform.position;
            element.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg);
            element.SetParameters(_poolBase);
        }
    }
}
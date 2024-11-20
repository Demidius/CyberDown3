using BsseCode.Caracters.Hero;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ShootFiresPool
{
    public class ShootFireSpawner : MonoBehaviour
    {
        private Transform _spawnPoint;
        
        private Vector2 _direction;
        private IInputService _inputService;
        private Player _player;
        private IPoolController _poolController;


        [Inject]
        public void Construct(IPoolController poolController, IInputService inputService, Player player )
        {
            _poolController = poolController;
            _player = player;
            _inputService = inputService;
        }

        private void Start()
        {
            _inputService.ShootType1 += Shoot;
            _spawnPoint = _player.BulletSpawnPoint.transform;
        }

        private void Update()
        {
            _inputService.Shoot();
            _direction = _spawnPoint.up ;
        }

        private void Shoot()
        {
            var element = _poolController.GetPool<ShootFire>().GetElement();
            element.transform.position = _spawnPoint.transform.position;
            element.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg);
        }
    }
}
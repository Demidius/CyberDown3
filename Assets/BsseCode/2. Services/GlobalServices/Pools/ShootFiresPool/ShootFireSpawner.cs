using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._5._GameEntities.Hero;
using BsseCode._5._GameEntities.Objects.ShootFire;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.Pools.ShootFiresPool
{
    public class ShootFireSpawner : MonoBehaviour
    {
        private Transform _spawnPoint;
        
        private Vector2 _direction;
        private IInputGlobalService _inputGlobalService;
        private Player _player;
        private IPoolController _poolController;


        [Inject]
        public void Construct(IPoolController poolController, IInputGlobalService inputGlobalService, Player player )
        {
            _poolController = poolController;
            _player = player;
            _inputGlobalService = inputGlobalService;
        }

        private void Start()
        {
            _inputGlobalService.ShootType1 += Shoot;
            _spawnPoint = _player.BulletSpawnPoint.transform;
        }

        private void Update()
        {
            _inputGlobalService.Shoot();
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
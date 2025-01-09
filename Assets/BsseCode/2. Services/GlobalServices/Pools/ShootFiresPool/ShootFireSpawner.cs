using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._5._GameEntities.Objects.ShootFire;
using BsseCode._5._GameEntities.PlayerModule;
using BsseCode._5._GameEntities.PlayerModule.PlayerHandlerFl;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.Pools.ShootFiresPool
{
    public class ShootFireSpawner : MonoBehaviour
    {
        private Transform _spawnPoint;
        
        private Vector2 _direction;
        private IInputGlobalService _inputGlobalService;
        private IPoolController _poolController;
        private PlayerHandler _playerHandler;
        private IPlayerModule _playerModule;


        [Inject]
        public void Construct(
            IPoolController poolController, 
            IInputGlobalService inputGlobalService, 
            PlayerHandler playerHandler, 
            IPlayerModule playerModule
            )
        {
            _playerModule = playerModule;
            _playerHandler = playerHandler;
            _poolController = poolController;            
            _inputGlobalService = inputGlobalService;
        }

        private void Start()
        {
            _inputGlobalService.ShootType1 += Shoot;
            // _spawnPoint = _playerHandler.CurrentPlayer.BulletSpawnPoint.transform;
            // _spawnPoint = _playerHandler.CurrentPlayer.BulletSpawnPoint.gameObject.transform;
        }

        private void Update()
        {
            if (!_spawnPoint)
            {
                _spawnPoint = _playerModule.GetBulletSpawnPointTransform();
            }
            _inputGlobalService.Shoot();
            _direction = _spawnPoint.up ;
        }

        private void Shoot() {
            
            var element = _poolController.GetPool<ShootFire>().GetElement();
            element.transform.position = _spawnPoint.transform.position;
            element.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg);
        }
    }
}
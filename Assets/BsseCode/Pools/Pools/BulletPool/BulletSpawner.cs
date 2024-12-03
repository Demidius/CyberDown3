using BsseCode.Audio;
using BsseCode.Audio.AudioSourcesHandlers;
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
        private Vector2 _direction;
        
        private IInputService _inputService;
        private IBulletCounter _bulletCounter;
        private IPoolController _poolController;
        private AudioTracksBase _audioTracksBase;


        [Inject]
        public void Construct(
            IPoolController poolController, 
            IInputService inputService, 
            IBulletCounter bulletCounter,
            AudioTracksBase audioTracksBase)
           
        {
            _audioTracksBase = audioTracksBase;
            _poolController = poolController;
            _bulletCounter = bulletCounter;
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
                var bullet = _poolController.GetPool<Bullet>().GetElement();
                bullet.transform.position = _bulletSpawnPoint.transform.position;
                bullet.SetParameters(_bulletSpeed, _direction);
                _bulletCounter.SubtractBullet();
                
                PlaySound(bullet);
            }
            else
            {
                Debug.Log("Gun is empty");
            }
        }

        private void PlaySound(Bullet bullet)
        {
            AudioManager.Instance.PlaySound(_audioTracksBase.shootTrack, useInstance: false, position: bullet.transform.position);
        }
    }
}
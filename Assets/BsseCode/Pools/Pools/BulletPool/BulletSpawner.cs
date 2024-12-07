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
        private IEnergyCounter _energyCounter;
        private IPoolController _poolController;
        private AudioTracksBase _audioTracksBase;


        [Inject]
        public void Construct(
            IPoolController poolController, 
            IInputService inputService, 
            IEnergyCounter energyCounter,
            AudioTracksBase audioTracksBase)
           
        {
            _audioTracksBase = audioTracksBase;
            _poolController = poolController;
            _energyCounter = energyCounter;
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
            if (_energyCounter.EnergyCount > 0)
            {
                var bullet = _poolController.GetPool<Bullet>().GetElement();
                bullet.transform.position = _bulletSpawnPoint.transform.position;
                bullet.SetParameters(_bulletSpeed, _direction);
                _energyCounter.SubtractEnergy(1);
                
                PlaySound();
            }
            else
            {
                AudioManager.Instance.PlaySound(_audioTracksBase.emptyBarSound, useInstance: false, position: this.transform.position);
            }
        }

        private void PlaySound()
        {
            AudioManager.Instance.PlaySound(_audioTracksBase.shootTrack, useInstance: false, position: this.transform.position);
        }
    }
}
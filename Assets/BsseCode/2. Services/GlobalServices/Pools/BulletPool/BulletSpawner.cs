using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.LevelServices.BulletCounter;
using BsseCode._5._GameEntities.Objects.Bullet;
using BsseCode._6._Audio.Data;
using BsseCode._6._Audio.Managers;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.Pools.BulletPool
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _bulletSpawnPoint;

        private readonly float _bulletSpeed = 10;
        private Vector2 _direction;
        
        private IInputGlobalService _inputGlobalService;
        private IEnergyCounter _energyCounter;
        private IPoolController _poolController;
        private AudioTracksBase _audioTracksBase;


        [Inject]
        public void Construct(
            IPoolController poolController, 
            IInputGlobalService inputGlobalService, 
            IEnergyCounter energyCounter,
            AudioTracksBase audioTracksBase)
           
        {
            _audioTracksBase = audioTracksBase;
            _poolController = poolController;
            _energyCounter = energyCounter;
            _inputGlobalService = inputGlobalService;
        }

        private void Start()
        {
            _inputGlobalService.ShootType1 += Shoot;
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
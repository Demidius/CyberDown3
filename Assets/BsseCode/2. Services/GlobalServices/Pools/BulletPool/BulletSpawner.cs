using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.LevelServices.BulletCounter;
using BsseCode._2._Services.ServiceLocator;
using BsseCode._5._GameEntities.Objects.Bullet;
using BsseCode._6._Audio.Data;
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
       
        private GameMachineStarter _gameMachineStarter;
        private IAudioServicesLocator _audioServicesLocator;


        [Inject]
        public void Construct(
            IPoolController poolController, 
            IInputGlobalService inputGlobalService, 
            IEnergyCounter energyCounter,
            IAudioServicesLocator audioServicesLocator,
          
            GameMachineStarter gameMachineStarter)
           
        {
            _audioServicesLocator = audioServicesLocator;
            _gameMachineStarter = gameMachineStarter;
           
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
                _audioServicesLocator.AudioManager.PlaySound(_audioServicesLocator.AudioTracksBase.emptyBarSound, useInstance: false, position: this.transform.position);
            }
        }

        private void PlaySound()
        {
            _audioServicesLocator.AudioManager.PlaySound(_audioServicesLocator.AudioTracksBase.shootTrack, useInstance: false, position: this.transform.position);
        }
    }
}
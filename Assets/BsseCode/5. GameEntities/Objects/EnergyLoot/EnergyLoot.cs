using System;
using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.GlobalServices.Pools;
using BsseCode._2._Services.LevelServices.BulletCounter;
using BsseCode._3._SupportCode.Tags;
using BsseCode._5._GameEntities.UnivercialUtils;
using BsseCode._6._Audio.Data;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.EnergyLoot
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class EnergyLoot : MonoBehaviour, IPoolsElement
    {
        private float _speed;
        
        private Coroutine _coroutineLifeRoutine;
        private IEnergyCounter _energyCounter;
        private IPoolController _poolController;
        private AudioTracksBase _audioTracksBase;
        private IGameMachineModule _gameMachineModule;

        [Inject]
        public void Construct(
            IPoolController poolController, 
            IEnergyCounter energyCounter, 
            AudioTracksBase audioTracksBase, 
            IGameMachineModule gameMachineModule)
        {
            _gameMachineModule = gameMachineModule;
            _audioTracksBase = audioTracksBase;
            _poolController = poolController;
            _energyCounter = energyCounter;

            _gameMachineModule.MenuState.OnMenuState += ReturnToPool;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerTag>(out PlayerTag player))
            {
                if (_energyCounter.AddEnergy() == true)
                {
                    ReturnToPool();
                }
            }
        }


        public void ReturnToPool()
        {
            _poolController.ReturnToPool(this);
        }

        private void OnDestroy()
        {
            _gameMachineModule.MenuState.OnMenuState -= ReturnToPool;
        }
    }
}

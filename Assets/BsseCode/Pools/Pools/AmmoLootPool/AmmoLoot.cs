using BsseCode.Audio.AudioSourcesHandlers;
using BsseCode.Mechanics.BulletCounter;
using BsseCode.Services;
using BsseCode.Tags;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.AmmoLootPool
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class AmmoLoot : MonoBehaviour, IPoolsElement
    {
        private float _speed;
        private MoveService _moveService;


        private Coroutine _coroutineLifeRoutine;
        private IEnergyCounter _energyCounter;
        private IPoolController _poolController;
        private AudioTracksBase _audioTracksBase;

        [Inject]
        public void Construct(IPoolController poolController, IEnergyCounter energyCounter, AudioTracksBase audioTracksBase)
        {
            _audioTracksBase = audioTracksBase;
            _poolController = poolController;
            _energyCounter = energyCounter;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerTag>(out PlayerTag player))
            {
                if (_energyCounter.AddEnergy() == true)
                {
                    Deactivate();
                    Debug.Log("Ammo Loot Deactivated");
                }
                else
                {
                    Debug.Log("Ammo Loot notDeactivated");
                }
            }
        }


        public void Deactivate()
        {
            _poolController.ReturnToPool(this);
        }
    }
}
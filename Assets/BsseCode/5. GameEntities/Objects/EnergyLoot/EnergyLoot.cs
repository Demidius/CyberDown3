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
        private PositionUpdateService _positionUpdateService;


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
                    Kill();
                }
            }
        }


        public void Kill()
        {
            _poolController.ReturnToPool(this);
        }
    }
}
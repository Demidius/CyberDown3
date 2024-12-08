using System;
using BsseCode._3._SupportCode.Constants;
using BsseCode._3._SupportCode.RandomNumder;
using BsseCode._6._Audio.Data;
using BsseCode._6._Audio.Managers;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.LevelServices.BulletCounter
{
    public class EnergyCounter : MonoBehaviour, IEnergyCounter
    {
        private readonly IRandomizerService _randomizerService;
        private readonly AudioTracksBase _audioTracksBase;
        
        public float EnergyCount { get; private set; }
        
        public event Action OnEnergyCountChanged;
        public event Action OnEnergyBarEmpty;

        [Inject]
        public EnergyCounter(IRandomizerService randomizerService, AudioTracksBase audioTracksBase)
        {
            _randomizerService = randomizerService ?? throw new ArgumentNullException(nameof(randomizerService));
            _audioTracksBase = audioTracksBase ?? throw new ArgumentNullException(nameof(audioTracksBase));
        }

        private void Awake()
        {
            EnergyCount = Const.MaxEnergyCount;
        }

        public bool AddEnergy()
        {
            if (EnergyCount < Const.MaxEnergyCount)
            {
                EnergyCount += _randomizerService.GetRandomValue(Const.MinValueEnergyFromLoot, Const.MaxValueEnergyFromLoot);
                if (EnergyCount > Const.MaxEnergyCount)
                {
                    EnergyCount = Const.MaxEnergyCount;
                }

                AudioManager.Instance.PlaySound(_audioTracksBase.refillEnergyBarSound, useInstance: false, position: transform.position);
                OnEnergyCountChanged?.Invoke();
                return true;
            }

            AudioManager.Instance.PlaySound(_audioTracksBase.energyBarIsFullSound, useInstance: false, position: transform.position);
            return false;
        }

        public void SubtractEnergy(float value)
        {
            EnergyCount -= value;
            if (EnergyCount < 0)
            {
                EnergyCount = 0;
            }
            
            OnEnergyCountChanged?.Invoke();
            
            if (EnergyCount < Const.ValueForEmptyEvent)
            {
                OnEnergyBarEmpty?.Invoke();
            }
        }
    }
}
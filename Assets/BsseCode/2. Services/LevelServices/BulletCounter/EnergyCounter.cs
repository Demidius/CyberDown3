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
        
        public event Action OnEnergyCountChanged;
        public event Action OnEnergyBarEmpty;

        private IRandomizerService _randomizerService;
        private AudioTracksBase _audioTracksBase;
        public float EnergyCount { get; private set; }

        [Inject]
        public void Construct(IRandomizerService randomizerService, AudioTracksBase audioTracksBase)
        {
            _audioTracksBase = audioTracksBase;
            _randomizerService = randomizerService;
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

                AudioManager.Instance.PlaySound(_audioTracksBase.refillEnergyBarSound, useInstance: false,
                    position: this.transform.position);

                if (EnergyCount > Const.MaxEnergyCount) // Исправление: если энергия превышает максимум
                {
                    EnergyCount = Const.MaxEnergyCount;
                }

                OnEnergyCountChanged?.Invoke();
                return true;
            }

            AudioManager.Instance.PlaySound(_audioTracksBase.energyBarIsFullSound, useInstance: false,
                position: this.transform.position);
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
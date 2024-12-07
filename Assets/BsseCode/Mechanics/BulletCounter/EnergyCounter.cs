using System;
using BsseCode.Audio.AudioSourcesHandlers;
using BsseCode.Constants;
using BsseCode.Services.RandomNumder;
using UnityEngine;
using Zenject;

namespace BsseCode.Mechanics.BulletCounter
{
    public class EnergyCounter : MonoBehaviour, IEnergyCounter
    {
        private IRandomizerService _randomizerService;
        private AudioTracksBase _audioTracksBase;
        public float EnergyCount { get; private set; }
        public event Action OnEnergyCountChanged;
        public event Action EnergyBarIsEmpty;

        [Inject]
        public void Construct(IRandomizerService randomizerService, AudioTracksBase audioTracksBase)
        {
            _audioTracksBase = audioTracksBase;
            _randomizerService = randomizerService;
        }


        private void Awake()
        {
            EnergyCount = Constants.Const.MaxEnergyCount;
        }

        public bool AddEnergy()
        {
            if (EnergyCount < Const.MaxEnergyCount)
            {
                EnergyCount += _randomizerService.GetRandomValue(1, 3);

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
            OnEnergyCountChanged?.Invoke();
            if (EnergyCount < 2)
            {
                EnergyBarIsEmpty?.Invoke();
            }
        }
    }
}
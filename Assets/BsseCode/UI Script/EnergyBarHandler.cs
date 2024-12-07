using System;
using BsseCode.Constants;
using BsseCode.Mechanics.BulletCounter;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode.UI_Script
{
    public class EnergyBarHandler : MonoBehaviour
    {
        [SerializeField] private Image healthBarImage;

        private IEnergyCounter _energyCounter;

        [Inject]
        public void Construct(IEnergyCounter energyCounter)
        {
            _energyCounter = energyCounter;
        }

        void Start()
        {
            UpdateHealthBar();
            _energyCounter.OnEnergyCountChanged += UpdateHealthBar;
        }

        private void UpdateHealthBar()
        { 
            healthBarImage.fillAmount = Const.MaxEnergyCount > 0 
                ? (float)_energyCounter.EnergyCount / Const.MaxEnergyCount 
                : 0;
        }

        private void OnDestroy()
        {
            _energyCounter.OnEnergyCountChanged -= UpdateHealthBar;
        }
    }
}
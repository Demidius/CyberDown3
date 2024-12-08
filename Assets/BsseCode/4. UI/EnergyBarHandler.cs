using BsseCode._2._Services.LevelServices.BulletCounter;
using BsseCode._3._SupportCode.Constants;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode._4._UI
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
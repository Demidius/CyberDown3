using System;

namespace BsseCode._2._Services.LevelServices.BulletCounter
{
    public interface IEnergyCounter
    {
        public event Action OnEnergyCountChanged;
        public event Action OnEnergyBarEmpty;
        float EnergyCount { get; }
        bool AddEnergy();
        public void SubtractEnergy(float value);
    }
}
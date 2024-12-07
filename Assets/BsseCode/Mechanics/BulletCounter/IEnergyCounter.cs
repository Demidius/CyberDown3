using System;

namespace BsseCode.Mechanics.BulletCounter
{
    public interface IEnergyCounter
    {
        public event Action OnEnergyCountChanged;
        public event Action EnergyBarIsEmpty;
        float EnergyCount { get; }
        bool AddEnergy();
        public void SubtractEnergy(float value);
    }
}
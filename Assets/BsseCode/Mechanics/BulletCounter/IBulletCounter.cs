using System;

namespace BsseCode.Mechanics.BulletCounter
{
    public interface IBulletCounter
    {
        public event Action OnBulletCountChanged;
        int BulletCount { get; }
        void AddBullet();
        void SubtractBullet();
    }
}
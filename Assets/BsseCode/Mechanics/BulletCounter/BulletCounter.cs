using System;
using BsseCode.Constants;
using UnityEngine;

namespace BsseCode.Mechanics.BulletCounter
{
    public class BulletCounter : MonoBehaviour, IBulletCounter
    {
        public int BulletCount { get; private set; }
        public event Action OnBulletCountChanged;

        private void Start()
        {
            BulletCount = Constans.StartCountBullet;
        }

        public void AddBullet()
        {
            BulletCount ++;
            OnBulletCountChanged?.Invoke();
        }

        public void SubtractBullet()
        {
            BulletCount --;
            OnBulletCountChanged?.Invoke();
        }

    }
}
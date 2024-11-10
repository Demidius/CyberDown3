using System;
using BsseCode.Constants;
using BsseCode.Services.RandomNumder;
using UnityEngine;
using Zenject;

namespace BsseCode.Mechanics.BulletCounter
{
    public class BulletCounter : MonoBehaviour, IBulletCounter
    {
        public int BulletCount { get; private set; }
        public event Action OnBulletCountChanged;

        [Inject]
        private IRandomizerService _randomizerService;
        
        private void Start()
        {
            BulletCount = Constants.Const.StartCountBullet;
        }

        public void AddBullet()
        {
            BulletCount += _randomizerService.GetRandomValue(1,3);
            OnBulletCountChanged?.Invoke();
        }

        public void SubtractBullet()
        {
            BulletCount --;
            OnBulletCountChanged?.Invoke();
        }

    }
}
using System;
using BsseCode.Mechanics.BulletCounter;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode.UI_Script
{
    public class BulletCounterText : MonoBehaviour
    {
        private Text _bulletCounterText;
        private IBulletCounter _bulletCounter;

        [Inject]
        public void Construct(IBulletCounter bulletCounter)
        {
            _bulletCounter = bulletCounter;
        }
        
        private void Start()
        {
            _bulletCounterText = GetComponent<Text>();
            UpdateText();
            _bulletCounter.OnBulletCountChanged += UpdateText;
        }

        private void UpdateText()
        {
            _bulletCounterText.text = _bulletCounter.BulletCount.ToString();
        }

        private void OnDestroy()
        {
            _bulletCounter.OnBulletCountChanged -= UpdateText;
        }
    }
}
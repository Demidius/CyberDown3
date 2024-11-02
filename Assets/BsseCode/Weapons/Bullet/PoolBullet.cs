using System;
using BsseCode.Services.Factory;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace BsseCode.Weapons.Bullet
{
    public class PoolBullet : MonoBehaviour, IPoolBullet
    {

        [SerializeField] private BsseCode.Weapons.Bullet.Bullet bulletPrefab;
        [SerializeField] private int baseSize = 10;

        public PoolComponent<Bullet> PoolComponent { get; private set; }
        private IFactoryComponent _factoryComponent;

        [Inject]
        public void Construct(IFactoryComponent factoryComponent)
        {
            _factoryComponent = factoryComponent;
        }

        private void Start()
        {
            PoolComponent = new PoolComponent<Bullet>(bulletPrefab, baseSize, this.transform, _factoryComponent);
        }

        public Bullet GetBullet()
        {
            var bullet = PoolComponent.GetElement();
            return bullet;
        }
    

}
}
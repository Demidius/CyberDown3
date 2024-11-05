using BsseCode.Pools.Weapons.Bullet;
using BsseCode.Services.Factory;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools
{
    public class PoolsBase : MonoBehaviour, IPoolsBase
    {

        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private int baseSize = 10;

        public PoolComponent<Bullet> BulletPoolComponent { get; set; }
        
        private IFactoryComponent _factoryComponent;

        [Inject]
        public void Construct(IFactoryComponent factoryComponent)
        {
            _factoryComponent = factoryComponent;
        }

        private void Start()
        {
            BulletPoolComponent = new PoolComponent<Bullet>(bulletPrefab, baseSize, this.transform, _factoryComponent);
        }
        
    

    }
}

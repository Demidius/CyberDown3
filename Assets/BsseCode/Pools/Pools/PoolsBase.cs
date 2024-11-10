using BsseCode.Pools.Pools.AmmoLootPool;
using BsseCode.Pools.Pools.BulletPool;
using BsseCode.Pools.Pools.EnemesPool;
using BsseCode.Pools.Pools.ExplosionPool;
using BsseCode.Pools.Pools.ExplosionResiduePool;
using BsseCode.Pools.Pools.ShootFiresPool;
using BsseCode.Services.Factory;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace BsseCode.Pools.Pools
{
    public class PoolsBase : MonoBehaviour, IPoolsBase
    {

        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private ShootFire shootFirePrefab;
        [SerializeField] private Explosion explosionPrefab;
        [SerializeField] private ExplosionResidue explosionResiduePrefab;
        [SerializeField] private AmmoLoot ammoLootPrefab;
        
        [SerializeField] private int baseSize = 10;

        public PoolComponent<Bullet> BulletPoolComponent { get; set; }
        public PoolComponent<Enemy> EnemyPoolComponent { get;  set; }
        public PoolComponent<ShootFire> ShootFirePoolComponent { get;  set; }
        public PoolComponent<Explosion> ExplosionComponent { get;  set; }
        public PoolComponent<ExplosionResidue> ExplosionResidueComponent { get;  set; }
        public PoolComponent<AmmoLoot> AmmoLootComponent { get;  set; }
        
      
        private IFactoryComponent _factoryComponent;

        [Inject]
        public void Construct(IFactoryComponent factoryComponent)
        {
            _factoryComponent = factoryComponent;
        }

        private void Start()
        {
            BulletPoolComponent = InitializePoolComponent(bulletPrefab, baseSize);
            EnemyPoolComponent = InitializePoolComponent(enemyPrefab, baseSize);
            ShootFirePoolComponent = InitializePoolComponent(shootFirePrefab, baseSize);
            ExplosionComponent = InitializePoolComponent(explosionPrefab, baseSize);
            ExplosionResidueComponent = InitializePoolComponent(explosionResiduePrefab, baseSize);
            AmmoLootComponent = InitializePoolComponent(ammoLootPrefab, baseSize);
        }
        private PoolComponent<T> InitializePoolComponent<T>(T prefab, int size) where T : MonoBehaviour
        {
            return new PoolComponent<T>(prefab, size, this.transform, _factoryComponent);
        }
        
        // private void OnDestroy()
        // {
        //     BulletPoolComponent?.Clear();
        //     EnemyPoolComponent?.Clear();
        //     ShootFirePoolComponent?.Clear();
        //     ExplosionComponent?.Clear();
        //     ExplosionResidueComponent?.Clear();
        //     AmmoLootComponent?.Clear();
        // }

    }
}

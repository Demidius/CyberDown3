using BsseCode.Pools.Weapons.Bullet;

namespace BsseCode.Pools.Enemes
{
    public interface IPoolEnemy1
    {
        Enemy GetEnemy();
        public PoolComponent<Enemy> PoolComponent { get;  }
    }
}
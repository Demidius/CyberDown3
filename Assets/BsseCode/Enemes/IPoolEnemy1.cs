using BsseCode.Weapons.Bullet;

namespace BsseCode.Enemes
{
    public interface IPoolEnemy1
    {
        Enemy GetEnemy();
        public PoolComponent<Enemy> PoolComponent { get;  }
    }
}
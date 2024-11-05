using BsseCode.Pools.Weapons.Bullet;

namespace BsseCode.Pools.Pools
{
    public interface IPoolsBase
    { 
        PoolComponent<Bullet> BulletPoolComponent { get; set; }
    }
}
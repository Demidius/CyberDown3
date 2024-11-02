using UnityEngine;

namespace BsseCode.Weapons.Bullet
{
    public interface IPoolBullet
    {
        Bullet GetBullet();
        public PoolComponent<Bullet> PoolComponent { get;  }
    }
}
using UnityEngine;

namespace BsseCode.Weapons.Bullet
{
    public interface IPoolBullet
    {
        void GetBullet(Vector3 direction, float speed);
    }
}
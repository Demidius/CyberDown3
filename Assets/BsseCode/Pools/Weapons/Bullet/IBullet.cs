using BsseCode.Pools.Pools;
using UnityEngine;

namespace BsseCode.Pools.Weapons.Bullet
{
    internal interface IBullet
    {
        void SetParameters(float speed, Vector2 direction, IPoolsBase poolBullet);

        public void Deactivate();
    }
}
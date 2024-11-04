using UnityEngine;

namespace BsseCode.Weapons.Bullet
{
    internal interface IBullet
    {
        void SetParameters(float speed, Vector2 direction, IPoolBullet poolBullet);

        public void Deactivate();
    }
}
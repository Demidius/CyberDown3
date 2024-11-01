namespace BsseCode.Weapons.Bullet
{
    internal interface IBullet
    {
        void SetParameters(float speed, PoolComponent<BsseCode.Weapons.Bullet.Bullet> poolComponent);
    }
}
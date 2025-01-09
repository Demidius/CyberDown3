using UnityEngine;

namespace BsseCode._5._GameEntities.PlayerModule.Components
{
    public class BulletSpawnPoint : MonoBehaviour, IBulletSpawnPoint
    {
        public Transform GetBulletSpawnPointTransform()
        {
            return transform;
        }
    }

    public interface IBulletSpawnPoint
    {
        public Transform GetBulletSpawnPointTransform();
    }
}
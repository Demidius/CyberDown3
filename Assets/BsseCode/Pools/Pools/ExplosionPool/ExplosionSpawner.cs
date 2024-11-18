using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ExplosionPool
{
    public class ExplosionSpawner : MonoBehaviour, IExplosionSpawner
    {
        private Transform _spawnPoint;
        private IPoolController _poolBase;
      
        [Inject]
        public void Construct(IPoolController poolBullet)
        {
            _poolBase = poolBullet;
        }

        public void Explosion(Vector2 position)
        {
            var element = _poolBase.GetPool<Explosion>().GetElement();;
            element.transform.position = position;
        }
    }

    public interface IExplosionSpawner
    {
        void Explosion(Vector2 position);
    }
}
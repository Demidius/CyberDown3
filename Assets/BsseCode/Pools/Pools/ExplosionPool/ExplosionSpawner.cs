using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ExplosionPool
{
    public class ExplosionSpawner : MonoBehaviour, IExplosionSpawner
    {
        private Transform _spawnPoint;
        private IPoolsBase _poolBase;
      
        [Inject]
        public void Construct(IPoolsBase poolBullet)
        {
            _poolBase = poolBullet;
        }

        public void Explosion(Vector2 position)
        {
            var element = _poolBase.ExplosionComponent.GetElement();
            element.transform.position = position;
        }
    }

    public interface IExplosionSpawner
    {
        void Explosion(Vector2 position);
    }
}
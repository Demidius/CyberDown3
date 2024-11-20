using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ExplosionPool
{
    public class ExplosionSpawner : MonoBehaviour, IExplosionSpawner
    {
        private Transform _spawnPoint;
        private IPoolController _poolController;


        [Inject]
        public void Construct(IPoolController poolController)
        {
            _poolController = poolController;
        }


        public void Explosion(Vector2 position)
        {
            var element = _poolController.GetPool<Explosion>().GetElement();
            element.transform.position = position;
        }
    }

    public interface IExplosionSpawner
    {
        void Explosion(Vector2 position);
    }
}
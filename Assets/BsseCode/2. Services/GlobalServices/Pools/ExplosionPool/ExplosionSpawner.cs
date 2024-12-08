using BsseCode._5._GameEntities.Objects.Explosion;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.Pools.ExplosionPool
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
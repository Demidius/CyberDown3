using BsseCode.Services.Factory;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.ExplosionPool
{
    public class ExplosionSpawner : MonoBehaviour, IExplosionSpawner
    {
        private Transform _spawnPoint;
        
        private IPoolsBase _poolBase;
      //  private Vector2 _direction;
      
        [Inject]
        public void Construct(IPoolsBase poolBullet)
        {
       
            _poolBase = poolBullet;
       
        }

        public void Explosion(Vector2 position)
        {
            var element = _poolBase.ExplosionComponent.GetElement();
            element.transform.position = position;
            //element.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg);
            element.SetParameters(_poolBase);
        }
    }

    public interface IExplosionSpawner
    {
        void Explosion(Vector2 position);
    }
}
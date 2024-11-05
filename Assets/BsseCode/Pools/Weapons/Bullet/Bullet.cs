using System.Collections;
using BsseCode.Pools.Pools;
using BsseCode.Services;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Weapons.Bullet
{
    public class Bullet : MonoBehaviour, IBullet, IpoolElement
    {
        [SerializeField] private float lifetime = 2f;

        private IPoolsBase _poolComponent;
        private float _speed;
        private MoveService _moveService;
        private Vector2 _direction;
       
        
        [Inject]
        public void Construct(MoveService moveService)
        {
            
            _moveService = moveService;
        }

        public void SetParameters(float speed, Vector2 direction, IPoolsBase poolBullet)
        {
            _poolComponent = poolBullet;
            _speed = speed;
            _direction =  direction.normalized;
            
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void Update()
        {
            Vector3 newPosition = _moveService.Move(_direction, _speed, this.transform.position );
            transform.position = newPosition;
        }
        
        
        
        private void OnEnable()
        {
            StartCoroutine(LifeRoutine());
        }

        private void OnDisable()
        {
            StopCoroutine(LifeRoutine());
        }

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSeconds(lifetime);
            Deactivate();
        }

        public void Deactivate()
        {
            _poolComponent.BulletPoolComponent?.ReturnToPool(this);
            
        }
    }
}
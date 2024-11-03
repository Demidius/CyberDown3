using System.Collections;
using BsseCode.Hero;
using BsseCode.Services;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Weapons.Bullet
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private float lifetime = 2f;

        private IPoolBullet _poolComponent;
        private float _speed;
        private MoveService _moveService;
        private Vector2 _direction;
        private ITimeService _timeService;
        
        [Inject]
        public void Construct(ITimeService timeService, MoveService moveService)
        {
            _timeService = timeService;
            _moveService = moveService;
        }

        public void SetParameters(float speed, Vector2 direction, IPoolBullet poolBullet)
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

        private void Deactivate()
        {
            _poolComponent.PoolComponent?.ReturnToPool(this);
            Debug.Log("Deactivated");
        }
    }
}
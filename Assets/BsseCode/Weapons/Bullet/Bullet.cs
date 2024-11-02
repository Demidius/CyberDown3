using System.Collections;
using BsseCode.Hero;
using BsseCode.Services;
using UnityEngine;

namespace BsseCode.Weapons.Bullet
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private float lifetime = 2f;

        private IPoolBullet _poolComponent;
        private float _speed;
        private readonly MoveService _moveService;
        private Vector2 _direction;

        public Bullet()
        {
            _moveService = new MoveService();
        }

        public void SetParameters(float speed, Vector2 direction, IPoolBullet poolBullet)
        {
            _poolComponent = poolBullet;
            _speed = speed;
            _direction = direction;
        }

        private void Update()
        {
            Vector3 newPosition = _moveService.Move( _direction , _speed, this.transform.position );
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
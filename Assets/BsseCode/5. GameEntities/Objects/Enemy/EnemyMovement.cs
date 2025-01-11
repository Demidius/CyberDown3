using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;

namespace BsseCode._5._GameEntities.Objects.Enemy
{
    public interface IEnemyMovement
    {
        void Initialize(IPositionUpdateService positionUpdateService, float speed, Transform target);
        void Move();
        void Rotate();
    }

    public class EnemyMovement : MonoBehaviour, IEnemyMovement
    {
        private Vector2 _moveDirection;
        private float _speed;
        private Transform _target;
        private IPositionUpdateService _positionUpdateService;

        public void Initialize(IPositionUpdateService positionUpdateService, float speed, Transform target)
        {
            _positionUpdateService = positionUpdateService;
            _speed = speed;
            _target = target;
        }

        public void Move()
        {
            _moveDirection = (_target.position - transform.position).normalized;
            transform.position = _positionUpdateService.Move(_moveDirection, _speed, transform.position);
        }

        public void Rotate()
        {
            float angle = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
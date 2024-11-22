using BsseCode.Services;
using UnityEngine;

namespace BsseCode.Pools.Pools.BulletPool
{
    public class BulletMover
    {
        private readonly MoveService _moveService;
        private Transform _transform;

        public BulletMover(MoveService moveService, Transform transform)
        {
            _moveService = moveService;
            _transform = transform;
        }

        public void Move(Vector2 direction, float speed)
        {
            _transform.position = _moveService.Move(direction, speed, _transform.position);
        }

        public void SetRotationBasedOnDirection(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
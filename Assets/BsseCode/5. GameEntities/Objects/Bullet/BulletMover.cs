using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;

namespace BsseCode._5._GameEntities.Objects.Bullet
{
    public class BulletMover
    {
        private readonly PositionUpdateService _positionUpdateService;
        private Transform _transform;

        public BulletMover(PositionUpdateService positionUpdateService, Transform transform)
        {
            _positionUpdateService = positionUpdateService;
            _transform = transform;
        }

        public void Move(Vector2 direction, float speed)
        {
            _transform.position = _positionUpdateService.Move(direction, speed, _transform.position);
        }

        public void SetRotationBasedOnDirection(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
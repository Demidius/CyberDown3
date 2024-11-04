using System;
using BsseCode.Hero;
using BsseCode.Services;
using BsseCode.Weapons.Bullet;
using UnityEngine;
using UnityEngine.Serialization;

namespace BsseCode.Enemes
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        private IPoolEnemy1 _poolEnemy1;
        private float _speed;

        private Player _player;

        private MoveService _moveService;
        private Vector2 _moveDirection;

        public void SetParameters(float speed, Player player, IPoolEnemy1 poolEnemy1, MoveService moveService)
        {
            _moveService = moveService;
            _poolEnemy1 = poolEnemy1;
            _speed = speed;
            _player = player;
            
           
        }

        private void Update()
        {
            if (_player)
            {
                Direction();
            }
            
            float angle = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void Direction()
        {
            _moveDirection = _player.transform.position - transform.position;
            _moveDirection.Normalize();
            Vector2 newPosition = _moveService.Move(_moveDirection, _speed, this.transform.position);
            transform.position = newPosition;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Bullet>(out Bullet bullet))
            {
                bullet.Deactivate();
                Deactivate();
            }
        }


        private void Deactivate()
        {
            _poolEnemy1.PoolComponent?.ReturnToPool(this);
        }
    }
}
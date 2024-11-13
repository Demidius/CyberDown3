using System.Collections;
using BsseCode.Caracters.Hero;
using BsseCode.Mechanics.GameResults;
using BsseCode.Pools.Pools.BulletPool;
using BsseCode.Pools.Pools.ExplosionPool;
using BsseCode.Services;
using BsseCode.Services.Coroutines;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.EnemesPool
{
    public class Enemy : MonoBehaviour, IPoolsElement
    {
        private ExplosionSpawner _explosionSpawner;

        private IPoolsBase _poolsBase;
        private float _speed;

        private Player _player;
        private MoveService _moveService;
        private Vector2 _moveDirection;
        private ICoroutineService _coroutineService;
        private KillsController _killsController;
        
        [Inject]
        public void Construct(MoveService moveService,  Player player, IPoolsBase poolBase, ICoroutineService coroutineService, KillsController killsController)
        {
            _player = player;
            _killsController = killsController;

            _coroutineService = coroutineService;
            _moveService = moveService;
            _poolsBase = poolBase;
           
        }

        public void SetParameters(float speed)
        {
            _speed = speed;
        }

        
        private void Update()
        {
            Direction();
            Rotation();
        }

        public void Deactivate()
        {
            _coroutineService.StartCoroutine(PostMortemEventHandler());

            _poolsBase.EnemyPoolComponent?.ReturnToPool(this);
        }

        private void Rotation()
        {
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
                _killsController.OnEnemyKilled();
                bullet.Deactivate();
                Deactivate();
            }
        }

        private IEnumerator PostMortemEventHandler()
        {
            CreateExplosion();
            yield return new WaitForSeconds(0.5f);
            CreateExplosionResidue();
            yield return new WaitForSeconds(0.2f);
            CreateAmmoLoot();
        }

        private void CreateExplosionResidue()
        {
            var element = _poolsBase.ExplosionResidueComponent.GetElement();
            element.transform.position = this.transform.position;
        }

        private void CreateExplosion()
        {
            var element = _poolsBase.ExplosionComponent.GetElement();
            element.transform.position = this.transform.position;
        } 
        private void CreateAmmoLoot()
        {
            var element = _poolsBase.AmmoLootComponent.GetElement();
            element.transform.position = this.transform.position;
        }
    }
}
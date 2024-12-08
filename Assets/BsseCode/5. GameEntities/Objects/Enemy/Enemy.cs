using System.Collections;
using BsseCode._2._Services.GlobalServices.Coroutines;
using BsseCode._2._Services.GlobalServices.Pools;
using BsseCode._2._Services.GlobalServices.Pools.ExplosionPool;
using BsseCode._2._Services.LevelServices.GameResults;
using BsseCode._5._GameEntities.Hero;
using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.Enemy
{
    public class Enemy : MonoBehaviour, IPoolsElement
    {
        private ExplosionSpawner _explosionSpawner;
        
        [SerializeField] private EnemyAudioController audioController;

        private IPoolController _poolController;
        private float _speed;

        private Player _player;
        private PositionUpdateService _positionUpdateService;
        private Vector2 _moveDirection;
        private ICoroutineGlobalService _coroutineGlobalService;
        private KillsController _killsController;
        
        [Inject]
        public void Construct(PositionUpdateService positionUpdateService,  Player player, IPoolController poolController, ICoroutineGlobalService coroutineGlobalService, KillsController killsController)
        {
            _player = player;
            _killsController = killsController;

            _coroutineGlobalService = coroutineGlobalService;
            _positionUpdateService = positionUpdateService;
            _poolController = poolController;
           
        }

        public void SetParameters(float speed)
        {
            _speed = speed;
            // audioController.PlayBlades();
        }

        
        private void Update()
        {
            Direction();
            Rotation();
        }

        public void Deactivate()
        {
            _coroutineGlobalService.StartCoroutine(PostMortemEventHandler());

            _poolController.ReturnToPool(this);
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
            Vector2 newPosition = _positionUpdateService.Move(_moveDirection, _speed, this.transform.position);
            transform.position = newPosition;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.TryGetComponent<Bullet.Bullet>(out Bullet.Bullet bullet))
            {
               Deactivate();
            }
        }

        private IEnumerator PostMortemEventHandler()
        {
            CreateExplosion();
            audioController.ExplosionSound();
            yield return new WaitForSeconds(0.1f);
            _killsController.OnEnemyKilled();
            yield return new WaitForSeconds(0.5f);
            CreateExplosionResidue();
            yield return new WaitForSeconds(0.2f);
            CreateAmmoLoot();
        }

        private void CreateExplosionResidue()
        {
            var element = _poolController.GetPool<AfterDeathMarks.AfterDeathMarks>().GetElement();
            element.transform.position = this.transform.position;
        }

        private void CreateExplosion()
        {
            var element = _poolController.GetPool<Explosion.Explosion>().GetElement();
            element.transform.position = this.transform.position;
        } 
        private void CreateAmmoLoot()
        {
            var element = _poolController.GetPool<EnergyLoot.EnergyLoot>().GetElement();
            element.transform.position = this.transform.position;
        }
    }
}
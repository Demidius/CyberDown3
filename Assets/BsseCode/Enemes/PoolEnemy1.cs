using BsseCode.Services.Factory;
using BsseCode.Weapons.Bullet;
using UnityEngine;
using Zenject;

namespace BsseCode.Enemes
{
    public class PoolEnemy1 : MonoBehaviour, IPoolEnemy1
    {
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private int baseSize = 10;

        public PoolComponent<Enemy> PoolComponent { get; private set; }
        private IFactoryComponent _factoryComponent;
        private PlayerFactory _playerFactory;

        [Inject]
        public void Construct(IFactoryComponent factoryComponent, PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _factoryComponent = factoryComponent;
        }

        private void Start()
        {
            PoolComponent = new PoolComponent<Enemy>(enemyPrefab, baseSize, this.transform, _factoryComponent);
        }

        public Enemy GetEnemy()
        {
            var enemy = PoolComponent.GetElement();
            return enemy;
        }
    }
}
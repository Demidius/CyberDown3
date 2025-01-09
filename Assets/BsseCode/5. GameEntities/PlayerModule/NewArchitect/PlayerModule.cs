using BsseCode._5._GameEntities.PlayerModule.Components;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.PlayerModule
{
    public class PlayerModule : IPlayerModule
    {
        private IBulletSpawnPoint _bulletSpawnPoint;
       

        private IPlayer _playerObject;

        [Inject]
        void Construct(
            IPlayer player,
            IBulletSpawnPoint bulletSpawnPoint
            
            )
        {
            _bulletSpawnPoint = bulletSpawnPoint;
            _playerObject = player;
        }

        public Transform GetBulletSpawnPointTransform()
        {
            return _bulletSpawnPoint.GetBulletSpawnPointTransform();
        }
        
        
        
        
        /*
        Точка доступа к игроку
        Создание игрока на сцене
        
        Движение
        поворот
        получение точки спавна пуль
        привязывать камеру? -в модуль камеры
        
        
        
        
        */
        
    }

    public interface IPlayerModule
    {

        public Transform GetBulletSpawnPointTransform();
    }
}
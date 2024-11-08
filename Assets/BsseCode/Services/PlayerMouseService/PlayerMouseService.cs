using BsseCode.Services.Factory;
using UnityEngine;


namespace BsseCode.Services.PlayerMouseService
{
    public class PlayerMouseService : IPlayerMouseService, IService
    {
        private Camera _camera;
        private PlayerFactory _playerFactory;

       
        public PlayerMouseService(Camera camera, PlayerFactory playerFactory)
        {
            _camera = camera;
            _playerFactory = playerFactory; 
        }
        
        public Vector2 GetDirection()
        {
            
            Vector3 mouseScreenPosition = new Vector3(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y, _camera.nearClipPlane);
            Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(mouseScreenPosition);

            
            
            Vector2 direction = new Vector2(
                mouseWorldPosition.x - _playerFactory.Player.transform.position.x,
                mouseWorldPosition.y - _playerFactory.Player.transform.position.y
            );
            
            return direction;
        }
    }
}
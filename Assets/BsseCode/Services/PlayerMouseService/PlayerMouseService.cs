using BsseCode.Caracters.Elements;
using BsseCode.Caracters.Hero;
using UnityEngine;

namespace BsseCode.Services.PlayerMouseService
{
    public class PlayerMouseService : IPlayerMouseService, IService
    {
        private Camera _camera;
        private Player _player;

        public PlayerMouseService(Camera camera, Player player)
        {
            _player = player;
            _camera = camera;
        }
        
        public Vector2 GetDirection()
        {
            return RotationUtils.GetDirectionToMouse(_player.transform.position, _camera);
        }
    }
}
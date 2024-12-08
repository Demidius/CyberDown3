using System;
using BsseCode._2._Services.GlobalServices;
using BsseCode._5._GameEntities.Hero;
using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;

namespace BsseCode._3._SupportCode.PlayerMouseService
{
    public class PlayerMouseGlobalService : IPlayerMouseService, IGlobalService
    {
        private readonly Camera _camera;
        private readonly Player _player;

        public PlayerMouseGlobalService(Camera camera, Player player)
        {
            _camera = camera ?? throw new ArgumentNullException(nameof(camera));
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }
        
        public Vector2 GetDirection()
        {
            return RotationUpdateService.GetDirectionToMouse(_player.transform.position, _camera);
        }
    }
}
using System;
using BsseCode.Services.Factory;
using BsseCode.Services.PlayerMouseService;
using UnityEngine;
using Zenject;

namespace BsseCode.Hero
{
    public class BodyRotation : MonoBehaviour
    {
        private IPlayerMouseService _playerMouseService;
        private Camera _camera;
        private PlayerFactory _playerFactory;

        [Inject]
        public void Construct(Camera camera, PlayerFactory playerFactory)
        {
            _camera = camera;
            _playerFactory = playerFactory; 
        }

        private void Start()
        {
            _playerMouseService = new PlayerMouseService(_camera, _playerFactory);
        }

        void Update()
        {
            var direction = _playerMouseService.GetDirection(); 

            transform.up = direction;
        }

        
    }
}
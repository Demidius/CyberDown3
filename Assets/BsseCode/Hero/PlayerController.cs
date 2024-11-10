using System;
using BsseCode.Constants;
using BsseCode.Services;
using BsseCode.Services.InputFol;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Hero
{
    public class PlayerController : MonoBehaviour
    {
        public Vector2 movementHeroDirection;
       
        private IInputService _inputService;
        private MoveService _moveService;
        private float _movementSpeed;
        
        [Inject]
        public void Construct(IInputService inputService, ITimeService timeService, MoveService moveService)
        {
            _inputService = inputService;
            _moveService = moveService;
        }

        private void Start()
        {
            _movementSpeed = Const.SpeedPlayer;
        }

        private void Update()
        {
            movementHeroDirection = _inputService.GetMovementInput();
          
            Vector3 newPosition  = _moveService.Move(movementHeroDirection, _movementSpeed, this.transform.position);
            transform.position = newPosition;
        }
    }
}
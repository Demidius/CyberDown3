using System;
using BsseCode.Constants;
using BsseCode.Services;
using BsseCode.Services.InputFol;
using UnityEngine;
using Zenject;

namespace BsseCode.Caracters.Hero.Components
{
    public class MoveHendler : MonoBehaviour
    {
        public Vector2 movementHeroDirection;

        private IInputService _inputService;
        private MoveService _moveService;
        private float _movementSpeed;
        public bool isMoving { get; private set; }

        public event Action OnMoving;

        [Inject]
        public void Construct(IInputService inputService, MoveService moveService)
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
            ImputDirection();
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            transform.position = _moveService.Move(movementHeroDirection, _movementSpeed, this.transform.position);
        }

        private void ImputDirection()
        {
            movementHeroDirection = _inputService.GetMovementInput();

            MovingAction();
        }

        private void MovingAction()
        {
            bool isCurrentlyMoving = movementHeroDirection.sqrMagnitude > 0.5f;

            // Проверка, чтобы событие вызывалось только при изменении состояния движения
            if (isCurrentlyMoving != isMoving)
            {
                isMoving = isCurrentlyMoving;
                OnMoving?.Invoke();
            }
        }
    }
}
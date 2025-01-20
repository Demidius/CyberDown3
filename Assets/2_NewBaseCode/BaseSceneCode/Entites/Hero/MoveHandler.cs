using System;
using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._3._SupportCode.Constants;
using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode.Entites.Hero
{
    public class MoveHandler : MonoBehaviour
    {
        public Vector2 movementHeroDirection;

        private IInputGlobalService _inputGlobalService;
        private IPositionUpdateService _positionUpdateService;
       
        public bool IsMoving { get; private set; }

        public event Action OnMovementStateChanged;

        [Inject]
        public void Construct(IInputGlobalService inputGlobalService, IPositionUpdateService positionUpdateService)
        {
            _inputGlobalService = inputGlobalService ?? throw new ArgumentNullException(nameof(inputGlobalService));
            _positionUpdateService = positionUpdateService ?? throw new ArgumentNullException(nameof(positionUpdateService));
        }

        private void Update()
        {
            InputDirection();
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            transform.position = _positionUpdateService.Move(movementHeroDirection,  Const.SpeedPlayer, this.transform.position);
        }

        private void InputDirection()
        {
            movementHeroDirection = _inputGlobalService.GetMovementInput();
            MovingAction();
        }

        private void MovingAction()
        {
            bool isCurrentlyMoving = movementHeroDirection.sqrMagnitude > 0.5f;
           
            if (isCurrentlyMoving != IsMoving)
            {
                IsMoving = isCurrentlyMoving;
                OnMovementStateChanged?.Invoke();
            }
        }
    }
}
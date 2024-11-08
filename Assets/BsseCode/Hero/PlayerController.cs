using BsseCode.Services;
using BsseCode.Services.InputFol;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Hero
{
    public class PlayerController : MonoBehaviour
    {
       
        private IInputService _inputService;
        private MoveService _moveService;

        public float movementSpeed;
        public Vector2 movementHeroDirection;

        [Inject]
        public void Construct(IInputService inputService, ITimeService timeService, MoveService moveService)
        {
            _inputService = inputService;
            _moveService = moveService;
        }

        private void Update()
        {
            movementHeroDirection = _inputService.GetMovementInput();
          
            Vector3 newPosition  = _moveService.Move(movementHeroDirection, movementSpeed, this.transform.position);
            transform.position = newPosition;
        }
    }
}
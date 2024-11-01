using BsseCode.Services.Input;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace BsseCode.Hero
{
    public class PlayerController : MonoBehaviour
    {
        private IInputService _inputService;
        public float movementSpeed;

        public Vector3 movementHeroDirection;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            Vector2 movementInput = _inputService.GetMovementInput();
            Move(movementInput);
        }

        private void Move(Vector2 direction)
        {
            movementHeroDirection = new Vector3(direction.x, direction.y, 0) * (movementSpeed * Time.deltaTime);
            transform.position += movementHeroDirection;
        }
    }
}
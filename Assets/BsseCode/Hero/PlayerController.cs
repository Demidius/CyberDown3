using BsseCode.Services;
using BsseCode.Services.Factory;
using BsseCode.Services.Input;
using BsseCode.Weapons.Bullet;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace BsseCode.Hero
{
    public class PlayerController : MonoBehaviour
    {
        private IInputService _inputService;
        public float movementSpeed;

        public Vector2 movementHeroDirection;
        private readonly MoveService _moveService;

        public PlayerController()
        {
            _moveService = new MoveService();
        }

        [Inject]
        public void Construct(IInputService inputService)
        {
           _inputService = inputService;
        }
      
        private void Update()
        {
            Vector2 movementHeroDirection = _inputService.GetMovementInput();
          
            Vector3 newPosition  = _moveService.Move(movementHeroDirection, movementSpeed, this.transform.position);
            transform.position = newPosition;
        }
    }
}

using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.UnivercialUtils;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1.Entites.Player.PlayerEllements
{
    public class ObjectRotation : MonoBehaviour, IObjectRotation
    {
        
        private IInputService _inputService;
        private IPlayerHandler _playerHandler;
        private RotationUpdateService _rotationUpdateService;

        [Inject]
        public void Construct(
            IInputService inputService,
            IPlayerHandler playerHandler,
            RotationUpdateService rotationUpdateService
            )
        {
            _rotationUpdateService = rotationUpdateService;
            _playerHandler = playerHandler;
            _inputService = inputService;
        }

        void Update()
        {
            RotationHandler(_inputService.MousePosition, _playerHandler.GetPlayerPosition());
        }

        private void RotationHandler(Vector2 mousePosition, Vector2 playerPosition)
        {
            var newDirectionBody = GetNewDirectionBody(mousePosition, playerPosition);
            _rotationUpdateService.RotateTowardsDirection(transform, newDirectionBody);
            Debug.Log(newDirectionBody);
        }


        private Vector2 GetNewDirectionBody(Vector2 mousePosition, Vector2 playerPosition)
        {
            var newBodyPosition = (mousePosition - playerPosition).normalized;
            return newBodyPosition;
        }
    }

    public interface IObjectRotation
    {
        // void GetNewDirectionBody(Vector3 newDirection);
    }
}
using _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices.UnivercialUtils;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1.Entites._1_Player.Legs1
{
    public class PlayerLegsRotation : MonoBehaviour
    {
        private IInputController _inputController;
        private Vector2 _lastDirection;

        [Inject]
        void Construct(
           
            IInputController inputController
        )
        {
            _inputController = inputController;
        }

        void Update()
        {
            if (_inputController.PlayerSmoothMoveDirection != Vector2.zero)
            {
                transform.up = _inputController.PlayerSmoothMoveDirection.normalized;
                _lastDirection = _inputController.PlayerSmoothMoveDirection;
            }
            else
            {
                transform.up = _lastDirection;
            }
        }
    }
}
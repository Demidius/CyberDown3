using _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices.UnivercialUtils;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol;
using _2_NewBaseCode.Level1.Entites._1_Player._1_PlayerHandler;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1.Entites._1_Player.Body1
{
    public class PlayerBodyRotation : MonoBehaviour, IObjectRotation
    {
        
        
        private IPlayerHandler _playerHandler;
     
        private IInputController _inputController;

        [Inject]
        public void Construct(
            IPlayerHandler playerHandler,
         
            IInputController inputController
            )
        {
            _inputController = inputController;
            _playerHandler = playerHandler;
        }

        void Update()
        {
            RotationHandler(_inputController.MousePosition, _playerHandler.GetPlayerPosition().position);
        }

        private void RotationHandler(Vector2 mousePosition, Vector2 playerPosition)
        {
            var newDirectionBody = GetNewDirectionBody(mousePosition, playerPosition);
            transform.up = newDirectionBody.normalized;
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
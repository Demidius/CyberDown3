using _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices._1_Const;
using _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices.UnivercialUtils;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1.Entites._1_Player._3_PlayerEllements
{
    public class MovePerInput : MonoBehaviour, IMovePerInput
    {
        private IPositionUpdateService _positionUpdateService;
        private IInputController _inputController;

        [Inject]
        void Construct(
            IPositionUpdateService positionUpdateService,
            IInputController inputController
            )
        {
            _inputController = inputController;
            _positionUpdateService = positionUpdateService;
        }

        private void Update()
        {
            PositionUpdate();
        }
        private void PositionUpdate()
        {
            this.transform.position = _positionUpdateService.Move(_inputController.PlayerMoveDirection, Const1.MoveSpeed, this.transform.position);
        }
     
    }

    public interface IMovePerInput
    {
    }
}
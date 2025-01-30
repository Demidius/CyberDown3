using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.UnivercialUtils;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1.Entites._1_Player.Legs1
{
    public class PlayerLegsRotation : MonoBehaviour
    {
        private IInputService _inputService;
        private RotationUpdateService _rotationUpdateService;

        [Inject]
        void Construct(
            IInputService inputService,
            RotationUpdateService rotationUpdateService
            )
        {
            _rotationUpdateService = rotationUpdateService;
            _inputService = inputService;
        }

        void Update()
        {
            _rotationUpdateService.RotateTowardsDirection(this.transform,_inputService.GetMovementDirectionInput());
        }
    }
}
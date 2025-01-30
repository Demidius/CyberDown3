using System;

using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices._1._Const;
using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.UnivercialUtils;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol;
using NewBaseCode.BaseScene.Services.TimeModule;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1.Entites._1_Player._3_PlayerEllements
{
    public class MovePerInput : MonoBehaviour, IMovePerInput
    {
        private IPositionUpdateService _positionUpdateService;
        private IInputService _inputService;
      


        [Inject]
        void Construct(
            IPositionUpdateService positionUpdateService,
            IInputService inputService
          
            )
        {
           
            _inputService = inputService;
            _positionUpdateService = positionUpdateService;
        }

        private void Update()
        {
            PositionUpdate();
        }
        private void PositionUpdate()
        {
            this.transform.position = _positionUpdateService.Move(_inputService.GetMovementDirectionInput(), Const1.MoveSpeed, this.transform.position);
        }
     
    }

    public interface IMovePerInput
    {
    }
}
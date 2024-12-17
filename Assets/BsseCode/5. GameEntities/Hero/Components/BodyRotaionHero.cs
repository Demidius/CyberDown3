using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Hero.Components
{
    public class BodyRotaionHero : MonoBehaviour
    {
       private Camera _camera;
       private IInputGlobalService _inputGlobalService;

       [Inject]
        public void Construct(Camera camera, IInputGlobalService inputGlobalService)
        {
            _inputGlobalService = inputGlobalService;
            _camera = camera;
        }

        void Update()
        {
            var direction = _inputGlobalService.GetDirectionToMouse(this.transform.position, _camera);
            RotationUpdateService.RotateTowardsDirection(transform, direction);
        }
    }
}
using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Hero.Components
{
    public class BodyRotaionHero : MonoBehaviour
    {
       private Camera _camera;
       
        [Inject]
        public void Construct(Camera camera)
        {
            _camera = camera;
        }

        void Update()
        {
            var direction = RotationUpdateService.GetDirectionToMouse(transform.position, _camera);
            RotationUpdateService.RotateTowardsDirection(transform, direction);
        }
    }
}
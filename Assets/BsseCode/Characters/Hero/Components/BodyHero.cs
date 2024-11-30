using BsseCode.Caracters.Elements;
using UnityEngine;
using Zenject;

namespace BsseCode.Caracters.Hero.Components
{
    public class BodyHero : MonoBehaviour
    {
       private Camera _camera;
       
        [Inject]
        public void Construct(Camera camera)
        {
            _camera = camera;
        }

        void Update()
        {
            var direction = RotationUtils.GetDirectionToMouse(transform.position, _camera);
            RotationUtils.RotateTowardsDirection(transform, direction);
        }
    }
}
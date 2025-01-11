using BsseCode._2._Services.GlobalServices.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.ShootFire
{
    public class AnimShootFire : MonoBehaviour
    {
        [SerializeField]  private Animator shootAnimator;
       
        private ITimeModule _timeModule;
         
        [Inject]
        public void Construct(ITimeModule timeModule)
        {
            _timeModule = timeModule;
        }
           
        private void Update()
        {
            shootAnimator.speed = _timeModule.GetTimeScale() * 4f;
        }
    }
}
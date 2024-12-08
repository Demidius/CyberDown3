using BsseCode._2._Services.GlobalServices.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.ShootFire
{
    public class AnimShootFire : MonoBehaviour
    {
        [SerializeField]  private Animator shootAnimator;
       
        private ITimeGlobalService _timeGlobalService;
         
        [Inject]
        public void Construct(ITimeGlobalService timeGlobalService)
        {
            _timeGlobalService = timeGlobalService;
        }
           
        private void Update()
        {
            shootAnimator.speed = _timeGlobalService.TimeScale * 4f;
        }
    }
}
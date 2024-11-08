using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Animations
{
    public class AnimShootFire : MonoBehaviour
    {
        [SerializeField]  private Animator _shootAnimator;
       
        private ITimeService _timeService;
         
        [Inject]
        public void Construct(ITimeService timeService)
        {
            _timeService = timeService;
        }
           
        private void Update()
        {
            _shootAnimator.speed = _timeService.TimeScale * 4f;
        }
    }
}
using BsseCode.Services.TimeProvider;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace BsseCode.Animations
{
    public class AnimShootFire : MonoBehaviour
    {
        [SerializeField]  private Animator shootAnimator;
       
        private ITimeService _timeService;
         
        [Inject]
        public void Construct(ITimeService timeService)
        {
            _timeService = timeService;
        }
           
        private void Update()
        {
            shootAnimator.speed = _timeService.TimeScale * 4f;
        }
    }
}
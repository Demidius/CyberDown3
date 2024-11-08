using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Animations
{
    public class AnimEnemy : MonoBehaviour
    {
        [SerializeField]  private Animator legsAnimator;
      
        private ITimeService _timeService;
         
        [Inject]
        public void Construct(ITimeService timeService)
        {
            _timeService = timeService;
        }
           
        private void Update()
        {
            legsAnimator.speed = _timeService.TimeScale;
        }
    }
}
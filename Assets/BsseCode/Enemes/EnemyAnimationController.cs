
using BsseCode.Constants;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;


namespace BsseCode.Hero
{
    public class EnemyAnimationController : MonoBehaviour
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
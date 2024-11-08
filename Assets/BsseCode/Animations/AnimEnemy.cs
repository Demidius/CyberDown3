using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Animations
{
    public class AnimEnemy : MonoBehaviour
    {
        [SerializeField]  private Animator legsAnimator;
        [SerializeField] private float legsAnimatorSpeed = 1f;
       
        [SerializeField]  private Animator knaifAnimatorR;
        [SerializeField]  private Animator knaifAnimatorL;
        [SerializeField] private float  knaifAnimatorSpeed = 1f;
        
        
        private ITimeService _timeService;
         
        [Inject]
        public void Construct(ITimeService timeService)
        {
            _timeService = timeService;
        }
        private void Update()
        {
            legsAnimator.speed = _timeService.TimeScale * legsAnimatorSpeed;
            knaifAnimatorR.speed = _timeService.TimeScale * knaifAnimatorSpeed;
            knaifAnimatorL.speed = _timeService.TimeScale * knaifAnimatorSpeed;
        }
    }
}
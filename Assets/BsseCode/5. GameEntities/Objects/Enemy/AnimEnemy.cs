using BsseCode._2._Services.GlobalServices.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.Enemy
{
    public class AnimEnemy : MonoBehaviour
    {
        [SerializeField]  private Animator legsAnimator;
        [SerializeField] private float legsAnimatorSpeed = 1f;
       
        [SerializeField]  private Animator knaifAnimatorR;
        [SerializeField]  private Animator knaifAnimatorL;
        [SerializeField] private float  knaifAnimatorSpeed = 1f;
        
        
        private ITimeGlobalService _timeGlobalService;
         
        [Inject]
        public void Construct(ITimeGlobalService timeGlobalService)
        {
            _timeGlobalService = timeGlobalService;
        }
        private void Update()
        {
            legsAnimator.speed = _timeGlobalService.TimeScale * legsAnimatorSpeed;
            knaifAnimatorR.speed = _timeGlobalService.TimeScale * knaifAnimatorSpeed;
            knaifAnimatorL.speed = _timeGlobalService.TimeScale * knaifAnimatorSpeed;
        }
    }
}
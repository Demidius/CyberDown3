using BsseCode._2._Services.GlobalServices.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.Enemy
{
    public class AnimEnemy : MonoBehaviour
    {
        [SerializeField]  private Animator legsAnimator;
        private float legsAnimatorSpeed = 1f;
        
        [SerializeField]  private Animator rightKnifeAnimator;
        [SerializeField]  private Animator leftKnifeAnimator;
        private float  knifeAnimatorSpeed = 1f;
        
        private ITimeGlobalService _timeGlobalService;
         
        [Inject]
        public void Construct(ITimeGlobalService timeGlobalService)
        {
            _timeGlobalService = timeGlobalService;
        }
        private void Update()
        {
            LegAnimatorController();
            KnifeAnimatorController();
        }

        private void KnifeAnimatorController()
        {
            rightKnifeAnimator.speed = _timeGlobalService.TimeScale * knifeAnimatorSpeed;
            leftKnifeAnimator.speed = _timeGlobalService.TimeScale * knifeAnimatorSpeed;
        }

        private void LegAnimatorController()
        {
            legsAnimator.speed = _timeGlobalService.TimeScale * legsAnimatorSpeed;
        }
    }
}
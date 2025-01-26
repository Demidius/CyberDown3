using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices.TimeProvider;
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
        
        private ITimeModule _timeModule;
         
        [Inject]
        public void Construct(ITimeModule timeModule)
        {
            _timeModule = timeModule;
        }
        private void Update()
        {
            LegAnimatorController();
            KnifeAnimatorController();
        }

        private void KnifeAnimatorController()
        {
            rightKnifeAnimator.speed = _timeModule.GetTimeScale() * knifeAnimatorSpeed;
            leftKnifeAnimator.speed = _timeModule.GetTimeScale() * knifeAnimatorSpeed;
        }

        private void LegAnimatorController()
        {
            legsAnimator.speed = _timeModule.GetTimeScale() * legsAnimatorSpeed;
        }
    }
}
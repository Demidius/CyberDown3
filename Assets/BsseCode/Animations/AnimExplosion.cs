using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Animations
{
    public class AnimExplosion : MonoBehaviour
    {
        [SerializeField]  private Animator _animator;
        [SerializeField] private float _animatorSpeed; 

        private ITimeService _timeService;
         
        [Inject]
        public void Construct(ITimeService timeService)
        {
            _timeService = timeService;
        }
           
        private void Update()
        {
            _animator.speed = Mathf.Clamp(_timeService.TimeScale, 0.3f, 1.0f);
        }
    }
}

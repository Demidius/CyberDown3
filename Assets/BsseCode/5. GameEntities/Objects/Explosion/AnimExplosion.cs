using BsseCode._2._Services.GlobalServices.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.Explosion
{
    public class AnimExplosion : MonoBehaviour
    {
        [SerializeField]  private Animator _animator;
        [SerializeField] private float _animatorSpeed; 

        private ITimeGlobalService _timeGlobalService;
         
        [Inject]
        public void Construct(ITimeGlobalService timeGlobalService)
        {
            _timeGlobalService = timeGlobalService;
        }
           
        private void Update()
        {
            _animator.speed = Mathf.Clamp(_timeGlobalService.TimeScale, 0.3f, 1.0f);
        }
    }
}

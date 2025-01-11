using BsseCode._2._Services.GlobalServices.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.Explosion
{
    public class AnimExplosion : MonoBehaviour
    {
        [SerializeField]  private Animator _animator;
        [SerializeField] private float _animatorSpeed; 

        private ITimeModule _timeModule;
         
        [Inject]
        public void Construct(ITimeModule timeModule)
        {
            _timeModule = timeModule;
        }
           
        private void Update()
        {
            _animator.speed = Mathf.Clamp(_timeModule.GetTimeScale(), 0.3f, 1.0f);
        }
    }
}

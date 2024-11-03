using BsseCode.Constants;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;


namespace BsseCode.Hero
{
    public class AnimationController : MonoBehaviour
    {
          [SerializeField]  private Animator legsAnimator;
           [SerializeField] private PlayerController player;
        
           private ITimeService _timeService;
         
           [Inject]
           public void Construct(ITimeService timeService)
           {
               _timeService = timeService;
           }
           
            private void Update()
            {
                if (player.movementHeroDirection != Vector2.zero )
                {
                    legsAnimator.SetBool(ConstansBase.Run, true );
                }
                else
                {
                    legsAnimator.SetBool(ConstansBase.Run, false );
                }
                
                
                legsAnimator.speed = _timeService.TimeScale;
            }
    }
}
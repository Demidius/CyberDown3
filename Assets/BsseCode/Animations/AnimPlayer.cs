using BsseCode.Constants;
using BsseCode.Hero;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.Animations
{
    public class AnimPlayer : MonoBehaviour
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
                    legsAnimator.SetBool(Constans.Run, true );
                }
                else
                {
                    legsAnimator.SetBool(Constans.Run, false );
                }
                
                
                legsAnimator.speed = _timeService.TimeScale;
            }
    }
}
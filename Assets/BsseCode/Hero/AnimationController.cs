using BsseCode.Constants;
using UnityEngine;


namespace BsseCode.Hero
{
    public class AnimationController : MonoBehaviour
    {
          [SerializeField]  private Animator legsAnimator;
           [SerializeField] private PlayerController player;
        
            private void Update()
            {
                if (player.movementHeroDirection != Vector3.zero )
                {
                    legsAnimator.SetBool(ConstansBase.Run, true );
                }
                else
                {
                    legsAnimator.SetBool(ConstansBase.Run, false );
                }
            }
    }
}
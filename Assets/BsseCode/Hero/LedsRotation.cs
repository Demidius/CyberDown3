using UnityEngine;

namespace BsseCode.Hero
{
    public class LedsRotation : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
       
        public Vector3 direction;

        void Update()
        {
            direction = player.movementHeroDirection;

            transform.up = direction;
        }
    }
}
using UnityEngine;

namespace BsseCode.Hero
{
    public class BodyRotation : MonoBehaviour
    {
        void Update()
        {
           
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
            
            Vector2 direction = new Vector2(
                mousePosition.x - transform.position.x, 
                mousePosition.y - transform.position.y
            );

           
            transform.up = direction;
        }
    }
}
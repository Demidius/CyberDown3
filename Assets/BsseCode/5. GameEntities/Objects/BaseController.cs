using BsseCode._3._SupportCode.Tags;
using BsseCode._5._GameEntities.Hero;
using UnityEngine;

namespace BsseCode._5._GameEntities.Objects
{
    public class BaseController : MonoBehaviour
    {
        [SerializeField] private GameObject greenBottom;
        [SerializeField] private GameObject redBottom;


        private void OnEnable()
        {
            greenBottom.SetActive(false);
            redBottom.SetActive(true);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerTag>(out PlayerTag player))
            {
                greenBottom.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerTag>(out PlayerTag player))
            {
                greenBottom.SetActive(false);
            }
        }
    }
}

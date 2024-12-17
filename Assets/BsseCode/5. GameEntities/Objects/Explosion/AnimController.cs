using UnityEngine;

namespace BsseCode._5._GameEntities.Objects.Explosion
{
    public class AnimController : MonoBehaviour
    {
        [SerializeField] private Explosion iPoolsElementObject;


        private void Deactivate()
        {
            iPoolsElementObject.Kill();
        }
    }
}

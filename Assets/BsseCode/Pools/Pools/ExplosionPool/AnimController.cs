using UnityEngine;

namespace BsseCode.Pools.Pools.ExplosionPool
{
    public class AnimController : MonoBehaviour
    {
        [SerializeField] private Explosion iPoolsElementObject;


        private void Deactivate()
        {
            iPoolsElementObject.Deactivate();
        }
    }
}

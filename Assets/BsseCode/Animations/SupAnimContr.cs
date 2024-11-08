using BsseCode.Pools.Pools;
using UnityEngine;

namespace BsseCode.Animations
{
    public class SupAnimContr : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour iPoolsElementObject; 
        private IPoolsElement _iPoolsElement;

        private void Awake()
        {
           
            _iPoolsElement = iPoolsElementObject as IPoolsElement;

            if (_iPoolsElement == null)
            {
                Debug.LogError("Assigned object does not implement IPoolsElement interface.");
            }
        }

        private void Deactivate()
        {
            if (_iPoolsElement != null)
            {
                _iPoolsElement.Deactivate();
            }
            else
            {
                Debug.LogError("Cannot deactivate: _iPoolsElement is null.");
            }
        }
    }
}
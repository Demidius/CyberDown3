using Unity.VisualScripting;
using UnityEngine;

namespace NewBaseCode.UI
{
    public class BasePanel : MonoBehaviour, IBasePanel
    {
        public void Activate()
        {
            this.GameObject().SetActive(true);
        } 
        
        public void Deactivate()
        {
            this.GameObject().SetActive(false);
        }
    }

    public interface IBasePanel
    {
        void Activate();
        void Deactivate();
    }
}
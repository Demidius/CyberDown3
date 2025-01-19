using Unity.VisualScripting;
using UnityEngine;

namespace NewBaseCode._3._UI._2.Pannels
{
    public class BasePanel : MonoBehaviour
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
}
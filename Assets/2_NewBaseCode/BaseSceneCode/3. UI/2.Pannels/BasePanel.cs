using Unity.VisualScripting;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._3._UI._2.Pannels
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
using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.BeaconHandler
{
    public class BeaconHandler : MonoBehaviour
    {
        public Vector3 BaaconControllerPosition { get; set; }
      
        public bool IsActive { get; set; }
        
        public void SetBaseController(Vector3 targetPosition)
        {
            Debug.Log("SetBaseController");
            BaaconControllerPosition = targetPosition;
            IsActive = true;
        }

        public void OnFillingEnded()
        {
            IsActive = false;
        }
    }
}
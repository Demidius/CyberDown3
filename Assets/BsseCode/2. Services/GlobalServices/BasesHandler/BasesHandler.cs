using System;
using BsseCode._5._GameEntities.Objects;
using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.BasesHandler
{
    public class BasesHandler : MonoBehaviour
    {
        public BaseController BaseController { get; set; }

        public event Action<Vector3> OnFillingStarted; // Событие начала заполнения
        public event Action OnFillingEndedEvent; // Событие завершения заполнения
        
        public void SetBaseController(BaseController controller)
        {
            Debug.Log("SetBaseController");
            BaseController = controller;
            OnFillingStarted?.Invoke(controller.transform.position);
        }

        public void OnFillingEnded()
        {
            OnFillingEndedEvent?.Invoke();
        }
    }
}
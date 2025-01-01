using System;
using BsseCode._5._GameEntities.Objects;
using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.BasesHandler
{
    public class BasesHandler : MonoBehaviour
    {
        public Vector2 BaseControllerPosition { get; set; }

        public event Action<Vector3> OnFillingStarted; // Событие начала заполнения
        public event Action OnFillingEndedEvent; // Событие завершения заполнения
        
        public void SetBaseController(Vector2 targetPosition)
        {
            Debug.Log("SetBaseController");
            BaseControllerPosition = targetPosition;
            OnFillingStarted?.Invoke(targetPosition);
        }

        public void OnFillingEnded()
        {
            OnFillingEndedEvent?.Invoke();
        }
    }
}
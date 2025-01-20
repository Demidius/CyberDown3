using Cinemachine;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler
{
    public class CameraHandler : MonoBehaviour, ICameraHandler
    {
        private CinemachineVirtualCamera vcam;

        void Awake()
        {
            // Инициализируем ссылку на Virtual Camera
            vcam = GetComponent<CinemachineVirtualCamera>();

            if (vcam == null)
            {
                Debug.LogError("CinemachineVirtualCamera не найден на объекте " + gameObject.name);
            }
        }

        /// <summary>
        /// Устанавливает объект, за которым камера будет следить.
        /// </summary>
        /// <param name="target">Объект, который камера должна следить.</param>
        public void Follow(GameObject target)
        {
            if (vcam == null)
            {
                Debug.LogWarning("CinemachineVirtualCamera не инициализирована.");
                return;
            }

            if (target != null)
            {
                vcam.Follow = target.transform;
            }
            else
            {
                Debug.LogWarning("Передан null в качестве объекта для слежения.");
            }
        }

        public void MoveTo(Vector3 position)
        {
            vcam.transform.position = position;
        }
        
    }

    public interface ICameraHandler
    {
        public void Follow(GameObject point);
        public void MoveTo(Vector3 position);
    }
}
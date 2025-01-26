using Cinemachine;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler
{
    public class CameraHandler : MonoBehaviour, ICameraHandler
    {
        private CinemachineVirtualCamera _vcam;
        private Camera _camera;

        void Awake()
        {
            // Инициализируем ссылку на Virtual Camera
            _vcam = GetComponent<CinemachineVirtualCamera>();

            if (_vcam == null)
            {
                Debug.LogError("CinemachineVirtualCamera не найден на объекте " + gameObject.name);
            }
            
            _camera = FindObjectOfType<Camera>();
            
        }

        /// <summary>
        /// Устанавливает объект, за которым камера будет следить.
        /// </summary>
        /// <param name="target">Объект, который камера должна следить.</param>
        public void Follow(GameObject target)
        {
            if (_vcam == null)
            {
                Debug.LogWarning("CinemachineVirtualCamera не инициализирована.");
                return;
            }

            if (target != null)
            {
                _vcam.Follow = target.transform;
            }
            else
            {
                Debug.LogWarning("Передан null в качестве объекта для слежения.");
            }
        }

        public void MoveTo(Vector3 position)
        {
            _vcam.transform.position = position;
        }

        public Camera GetCamera()
        {
            return _camera;
        }

        public CinemachineVirtualCamera GetVirtualCamera()
        {
            return _vcam;
        }
    }

    public interface ICameraHandler
    {
        public void Follow(GameObject point);
        public void MoveTo(Vector3 position);
        Camera GetCamera();
        CinemachineVirtualCamera GetVirtualCamera();
    }
}
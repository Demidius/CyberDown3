using Cinemachine;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.ServiceLocator
{
    public class CameraServiceLocator : ICameraServiceLocator
    {
        public CinemachineVirtualCamera CinemachineVirtualCamera { get; private set; }
        public Camera Camera1 { get; private set; }

        [Inject]
        void Construct(Camera camera, CinemachineVirtualCamera vcam)
        {
            CinemachineVirtualCamera = vcam;
            Camera1 = camera;
        }
        
    }

    public interface ICameraServiceLocator
    {
        public Camera Camera1 { get; }
        public CinemachineVirtualCamera CinemachineVirtualCamera { get; }
    }
}

using Cinemachine;
using UnityEngine;
using Zenject;

namespace BsseCode.Installers
{
    public class CamerasInstaller  : MonoInstaller
    {
        public override void InstallBindings()
        {
            CinemachineVirtualCamera virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
            
            if (virtualCamera != null)
            {
                Container.Bind<CinemachineVirtualCamera>().FromInstance(virtualCamera).AsSingle();
            }
            else
            {
                Debug.LogError("Cinemachine Virtual Camera not found in the scene.");
            }
            
            Camera Camera = FindObjectOfType<Camera>();
            
            if (Camera != null)
            {
                Container.Bind<Camera>().FromInstance(Camera).AsSingle();
            }
            else
            {
                Debug.LogError("Camera not found in the scene.");
            }
            
            
            
        }
    }
}
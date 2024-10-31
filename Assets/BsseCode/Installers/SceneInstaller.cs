
using Cinemachine;
using UnityEngine;
using Zenject;

namespace BsseCode.Installers
{
    public class SceneInstaller  : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Найти основную камеру
            CinemachineVirtualCamera virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

            // Проверка, что камера найдена
            if (virtualCamera != null)
            {
                // Регистрация камеры в контейнере
                Container.Bind<CinemachineVirtualCamera>().FromInstance(virtualCamera).AsSingle();
            }
            else
            {
                Debug.LogError("Cinemachine Virtual Camera not found in the scene.");
            }
        }
    }
}
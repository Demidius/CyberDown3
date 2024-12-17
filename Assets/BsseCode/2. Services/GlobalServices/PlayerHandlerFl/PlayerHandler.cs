using BsseCode._2._Services.GlobalServices.Factory;
using BsseCode._5._GameEntities.Hero;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace BsseCode._2._Services.GlobalServices.PlayerHandlerFl
{
    public class PlayerHandler : MonoBehaviour
    {
        [SerializeField] private Player playerPrefs;
        private IFactoryComponent _factoryComponent;
        private CinemachineVirtualCamera _vcam;

        [Inject]
        void Construct(IFactoryComponent factoryComponent, CinemachineVirtualCamera vcam)
        {
            _vcam = vcam;
            _factoryComponent = factoryComponent;
        }

        public Player CurrentPlayer { get; private set; }

        public void CreatePlayer()
        {
            if (CurrentPlayer == null)
                CurrentPlayer = _factoryComponent.Create(playerPrefs);
            if (CurrentPlayer.GameObject().activeSelf == false)
            {
                CurrentPlayer.GameObject().SetActive(true);
                _vcam.Follow = CurrentPlayer.transform;
                CurrentPlayer.GameObject().transform.position = Vector3.zero;
            }
        }

        public void DestroyPlayer()
        {
            CurrentPlayer.GameObject().SetActive(false);
        }
    }
}
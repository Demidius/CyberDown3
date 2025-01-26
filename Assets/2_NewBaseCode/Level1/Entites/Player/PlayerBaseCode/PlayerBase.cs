using _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1.Entites.Player.PlayerBaseCode
{
    public class PlayerBase : MonoBehaviour, IPlayerBase
    {
        private ICameraHandler _cameraHandler;

        [Inject]
        void Construct(ICameraHandler cameraHandler)
        {
            _cameraHandler = cameraHandler;
        }

        void Start()
        {
            _cameraHandler.GetVirtualCamera().Follow = transform;
        }
      
    }

    public interface IPlayerBase
    {
       
    }
}
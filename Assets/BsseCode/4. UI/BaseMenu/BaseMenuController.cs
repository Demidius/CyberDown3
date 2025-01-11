using System;
using BsseCode._1._StateMachines.GameStateMachine;
using UnityEngine;
using Zenject;

namespace BsseCode._4._UI.BaseMenu
{
    public class BaseMenuController : MonoBehaviour
    {
        [SerializeField] GameObject baseMenu;
       
        private IGameMachineModule _module;

        [Inject]
        void Construct(IGameMachineModule module)
        {
            _module = module;
        }

        void Start()
        {
            _module.GameplayState.OnGameState += DisableMenu;
        }

        private void DisableMenu()
        {
            baseMenu.SetActive(false);
        }


        private void OnDestroy()
        {
            _module.GameplayState.OnGameState -= DisableMenu;
        }
        
    }
}
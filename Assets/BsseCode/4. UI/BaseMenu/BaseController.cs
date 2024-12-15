using System;
using BsseCode._1._StateMachines.GameStateMachine;
using UnityEngine;
using Zenject;

namespace BsseCode._4._UI.BaseMenu
{
    public class BaseController : MonoBehaviour
    {
        [SerializeField] GameObject baseMenu;
        
        private GameMachineStarter _starter;

        [Inject]
        void Construct(GameMachineStarter starter)
        {
            _starter = starter;
        }

        void Start()
        {
            _starter.GameplayState.OnGameState += DisableMenu;
        }

        private void DisableMenu()
        {
            baseMenu.SetActive(false);
        }


        private void OnDestroy()
        {
            _starter.GameplayState.OnGameState -= DisableMenu;
        }
        
    }
}
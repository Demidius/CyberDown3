using System;
using BsseCode._1._StateMachines.GameStateMachine.States;
using BsseCode._6._Audio.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode._1._StateMachines.GameStateMachine
{
    public class MenuHandler : MonoBehaviour
    {
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button onParametrsButton;
        [SerializeField] private Button onAutorsButton;
        
        [SerializeField] private Button returnFromNewGameButton;
        [SerializeField] private Button returnFromParametrsButton;
        [SerializeField] private Button returnFromAutorsButton;
        
        [SerializeField] private Button startGameButton;
        
        
        [SerializeField] private GameObject menu;
        [SerializeField] private GameObject newMenu;
        [SerializeField] private GameObject parametrs;
        [SerializeField] private GameObject autors;
       
        private GameMachineStarter _starter;

        [Inject]
        public void Construct(GameMachineStarter starter)
        {
            _starter = starter;
        }

        private void Start()
        {
            newGameButton.onClick.AddListener(OnNewGameButton);
            onParametrsButton.onClick.AddListener(OnPrametrs);
            onAutorsButton.onClick.AddListener(OnAutors);
            
            returnFromNewGameButton.onClick.AddListener(OnMenu);
            returnFromParametrsButton.onClick.AddListener(OnMenu);
            returnFromAutorsButton.onClick.AddListener(OnMenu);
            
            startGameButton.onClick.AddListener(StartGame);
        }


        private void OnNewGameButton()
        {
            menu.SetActive(false);
            newMenu.SetActive(true);
            parametrs.SetActive(false);
            autors.SetActive(false);
        }

        private void StartGame()
        {
            _starter.MainMenuState.StartGame();
        }


        void OnMenu()
        {
            menu.SetActive(true);
            newMenu.SetActive(false);
            parametrs.SetActive(false);
            autors.SetActive(false);
        } 
        void OnPrametrs()
        {
            menu.SetActive(false);
            newMenu.SetActive(false);
            parametrs.SetActive(true);
            autors.SetActive(false);
        }
        
        void OnAutors()
        {
            menu.SetActive(false);
            newMenu.SetActive(false);
            parametrs.SetActive(false);
            autors.SetActive(true);
        }
        
        
        
    }
}
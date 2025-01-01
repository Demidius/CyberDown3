using BsseCode._1._StateMachines.GameStateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BsseCode._4._UI.BaseMenu
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
        
        [SerializeField] private Button resultsCleanerButton;
        
        
        
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
            resultsCleanerButton.onClick.AddListener(ResultsCleaner);
        }


        private void OnNewGameButton()
        {
            _starter.audioManager.PlaySound(_starter.audioTracksBase.click1Sound, useInstance: false, position: this.transform.position);

            menu.SetActive(false);
            newMenu.SetActive(true);
            parametrs.SetActive(false);
            autors.SetActive(false);
        }

        private void StartGame()
        {
            _starter.audioManager.PlaySound(_starter.audioTracksBase.click1Sound, useInstance: false, position: this.transform.position);

            _starter.MainMenuState.StartGame();
        }


        void OnMenu()
        {
            _starter.audioManager.PlaySound(_starter.audioTracksBase.click1Sound, useInstance: false, position: this.transform.position);
            
            menu.SetActive(true);
            newMenu.SetActive(false);
            parametrs.SetActive(false);
            autors.SetActive(false);
            
        } 
        void OnPrametrs()
        {
            _starter.audioManager.PlaySound(_starter.audioTracksBase.click1Sound, useInstance: false, position: this.transform.position);

            menu.SetActive(false);
            newMenu.SetActive(false);
            parametrs.SetActive(true);
            autors.SetActive(false);
            _starter.uiController.ResultsUI.DisplayResults();
        }
        
        void OnAutors()
        {
            _starter.audioManager.PlaySound(_starter.audioTracksBase.click1Sound, useInstance: false, position: this.transform.position);

            menu.SetActive(false);
            newMenu.SetActive(false);
            parametrs.SetActive(false);
            autors.SetActive(true);
        }

        void ResultsCleaner()
        {
            _starter.audioManager.PlaySound(_starter.audioTracksBase.click1Sound, useInstance: false, position: this.transform.position);

            _starter.resultsManager.ClearResults();
        }

    }
}
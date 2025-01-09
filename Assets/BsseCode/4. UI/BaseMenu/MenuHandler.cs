using BsseCode._1._StateMachines.GameStateMachine;
using BsseCode._2._Services.ServiceLocator;
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
        private IUIServiceLocator _uiServiceLocator;
        private IManagersServiceLocator _managersServiceLocator;
        private IAudioServicesLocator _audioServicesLocator;


        [Inject]
        public void Construct(
            GameMachineStarter starter, 
            IUIServiceLocator uiServiceLocator, 
            IManagersServiceLocator managersServiceLocator,
            IAudioServicesLocator audioServicesLocator
            )
        {
            _audioServicesLocator = audioServicesLocator;
            _managersServiceLocator = managersServiceLocator;
            _uiServiceLocator = uiServiceLocator;
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
            ExitSoudPlay();

            menu.SetActive(false);
            newMenu.SetActive(true);
            parametrs.SetActive(false);
            autors.SetActive(false);
        }

        private void ExitSoudPlay()
        {
            _audioServicesLocator.AudioManager.PlaySound(_audioServicesLocator.AudioTracksBase.clickExit);
        }
        private void EnterLevelSoudPlay()
        {
            _audioServicesLocator.AudioManager.PlaySound(_audioServicesLocator.AudioTracksBase.levelStartSound);
        }

        private void StartGame()
        {
            EnterLevelSoudPlay();

            _starter.MainMenuState.StartGame();
        }


        void OnMenu()
        {
            ExitSoudPlay();
            
            menu.SetActive(true);
            newMenu.SetActive(false);
            parametrs.SetActive(false);
            autors.SetActive(false);
            
        } 
        void OnPrametrs()
        {
            ExitSoudPlay();

            menu.SetActive(false);
            newMenu.SetActive(false);
            parametrs.SetActive(true);
            autors.SetActive(false);
            _uiServiceLocator.UIController.ResultsUI.DisplayResults();
        }
        
        void OnAutors()
        {
            ExitSoudPlay();

            menu.SetActive(false);
            newMenu.SetActive(false);
            parametrs.SetActive(false);
            autors.SetActive(true);
        }

        void ResultsCleaner()
        {
            ExitSoudPlay();

            _managersServiceLocator.ResultsManager.ClearResults();
        }

    }
}
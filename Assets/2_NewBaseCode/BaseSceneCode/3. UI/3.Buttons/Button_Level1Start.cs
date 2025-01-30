using _2_NewBaseCode.BaseSceneCode._1_GameMachine;
using _2_NewBaseCode.BaseSceneCode._1_GameMachine.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode._3._UI._3.Buttons
{
    public class ButtonLevel1Start : MonoBehaviour
    {
        private IStateSwitcher _stateSwitcher;

        [Inject]
        void Construct(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }
        void Start()    
        {
            GetComponent<Button>().onClick.AddListener(_stateSwitcher.StartFirstLevel);
        }
    }
}
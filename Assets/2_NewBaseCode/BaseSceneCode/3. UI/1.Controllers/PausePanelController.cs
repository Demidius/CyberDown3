using _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices.ColorHeaders;
using _2_NewBaseCode.BaseSceneCode._3._UI._2.Pannels;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._3._UI._1.Controllers
{
    public class PausePanelController : MonoBehaviour, IPausePanelController
    {
        [ColoredHeader("PausePanel", NamedColor.Orange, 14)] [SerializeField]
        private BasePanel pausePanel;
       
        public void EnterOnPausePanel()
        {
            pausePanel.Activate();
        }

        public void ExitOnPausePanel()
        {
            pausePanel.Deactivate();
        }
        
    }

    public interface IPausePanelController
    {
        void EnterOnPausePanel();
        void ExitOnPausePanel();
    }
}
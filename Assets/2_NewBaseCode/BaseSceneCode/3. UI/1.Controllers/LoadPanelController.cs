using _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices.ColorHeaders;
using _2_NewBaseCode.BaseSceneCode._3._UI._2.Pannels;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode._3._UI._1.Controllers
{
    public class LoadPanelController : MonoBehaviour, ILoadPanelController
    {
        [ColoredHeader("MenuPanel", NamedColor.Orange, 14)] [SerializeField]
        private BasePanel loadPanel;
       
        public void EnterOnLoadPanel()
        {
            loadPanel.Activate();
        }

        public void ExitOnLoadPanel()
        {
            loadPanel.Deactivate();
        }
        
    }

    public interface ILoadPanelController
    {
        void EnterOnLoadPanel();
        void ExitOnLoadPanel();
    }
}
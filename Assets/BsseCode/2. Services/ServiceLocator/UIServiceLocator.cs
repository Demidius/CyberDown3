using BsseCode._4._UI;
using Zenject;

namespace BsseCode._2._Services.ServiceLocator
{
    public class UIServiceLocator : IUIServiceLocator

    {
        [Inject]
        void Construct(UIController uiController)
        {
            this.UIController = uiController;
        }

        public UIController UIController { get; set; }
    }

    public interface IUIServiceLocator
    {
        public UIController UIController { get; set; }
    }
}
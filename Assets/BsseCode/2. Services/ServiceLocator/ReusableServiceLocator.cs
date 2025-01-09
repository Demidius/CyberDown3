using BsseCode._2._Services.GlobalServices.Coroutines;
using BsseCode._2._Services.GlobalServices.Factory;
using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using Cinemachine;
using Zenject;

namespace BsseCode._2._Services.ServiceLocator
{
    public class ReusableServiceLocator : IReusableServiceLocator
    {
        public IFactoryComponent FactoryComponent { get; set; }
        public ICoroutineGlobalService CoroutineGlobalService { get; private set; }
        public ITimeGlobalService TimeGlobalService { get; private set; }
        public IInputGlobalService PCInputGlobalService { get; private set; }

        [Inject]
        void Construct( 
            IInputGlobalService pcInputGlobalService,
            ITimeGlobalService timeGlobalService,
            ICoroutineGlobalService coroutineGlobalService,
            IFactoryComponent factoryComponent
            )
        {
            FactoryComponent = factoryComponent;
            CoroutineGlobalService = coroutineGlobalService;
            TimeGlobalService = timeGlobalService;
            PCInputGlobalService = pcInputGlobalService;
        }
    }

    public interface IReusableServiceLocator
    {
        public IInputGlobalService PCInputGlobalService { get; }
        public ITimeGlobalService TimeGlobalService { get; }
        public ICoroutineGlobalService CoroutineGlobalService { get; }
        public IFactoryComponent FactoryComponent { get; }
    }
}
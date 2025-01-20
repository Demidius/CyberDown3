using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.Coroutines;
using BsseCode._2._Services.GlobalServices.InputFol;
using BsseCode._2._Services.GlobalServices.TimeProvider;
using Cinemachine;
using Zenject;

namespace BsseCode._2._Services.ServiceLocator
{
    public class ReusableServiceLocator : IReusableServiceLocator
    {
        public ICoroutineGlobalService CoroutineGlobalService { get; private set; }
        public ITimeModule TimeModule { get; private set; }
        public IInputGlobalService PCInputGlobalService { get; private set; }

        [Inject]
        void Construct( 
            IInputGlobalService pcInputGlobalService,
            ITimeModule timeModule,
            ICoroutineGlobalService coroutineGlobalService,
            CinemachineVirtualCamera vcam
            )
        {
            CoroutineGlobalService = coroutineGlobalService;
            TimeModule = timeModule;
            PCInputGlobalService = pcInputGlobalService;
        }
    }

    public interface IReusableServiceLocator
    {
        public IInputGlobalService PCInputGlobalService { get; }
        public ITimeModule TimeModule { get; }
        public ICoroutineGlobalService CoroutineGlobalService { get; }
    }
}
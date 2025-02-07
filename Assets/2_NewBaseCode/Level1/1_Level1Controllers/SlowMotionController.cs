using System;
using _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices._1_Const;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.TimeModule;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1._1_Level1Controllers
{
    public class SlowMotionController : MonoBehaviour, ISlowMotionController
    {
        private readonly float SlowTimeScale = Const1.SlowTimeScale;
        private readonly float NormalTimeScale = Const1.NormalTimeScale;
        private bool _onSlowGameType;
        private ITimeManager _timeManager;
       

        [Inject]
        void Construct(ITimeManager timeManager)
        {
            _timeManager = timeManager ?? throw new ArgumentNullException(nameof(timeManager));
        }

        public void SetBaseLevelTimeScale()
        {
            _timeManager.SetNewTimeScale(NormalTimeScale);
        }

        public void SwitchGameType()
        {
            _onSlowGameType = !_onSlowGameType;
            _timeManager.SetNewTimeScale(_onSlowGameType ? SlowTimeScale : NormalTimeScale);
        }

        private void Awake()
        {
            
        }

        private void OnDestroy()
        {
         
        }
    }

    public interface ISlowMotionController
    {
        void SetBaseLevelTimeScale();
        void SwitchGameType();
    }
}
using System;
using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices._1._Const;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol;
using NewBaseCode.BaseScene.Services.TimeModule;

using UnityEngine;
using Zenject;

namespace NewBaseCode.Level1.Level1Services.SlowMotionTypeControllers
{
    public class SlowMotionController : MonoBehaviour, ISlowMotionController
    {
        private readonly float SlowTimeScale = Const1.SlowTimeScale;
        private readonly float NormalTimeScale = Const1.NormalTimeScale;
        private bool _onSlowGameType;
        private ITimeManager _timeManager;
        private IInputService _inputService;

        [Inject]
        void Construct(IInputService inputService, ITimeManager timeManager)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
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
            _inputService.SpaseKeyDown += SwitchGameType;
        }

        private void OnDestroy()
        {
            _inputService.SpaseKeyDown -= SwitchGameType;
        }
    }

    public interface ISlowMotionController
    {
        void SetBaseLevelTimeScale();
        void SwitchGameType();
    }
}
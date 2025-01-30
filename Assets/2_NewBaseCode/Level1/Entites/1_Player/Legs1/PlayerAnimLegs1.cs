using System;
using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices._1._Const;
using _2_NewBaseCode.BaseSceneCode._2._Sevices.InputFol;
using NewBaseCode.BaseScene.Services.TimeModule;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1.Entites._1_Player.Legs1
{
    public class PlayerAnimLegs1 : MonoBehaviour
    {
        private static readonly int PlayerGo = Animator.StringToHash("PlayerGo");
        [SerializeField] private Animator legs1Animator;
        private IInputService _inputService;
        private ITimeManager _timeManager;


        [Inject]
        void Construct(
            IInputService inputService,
            ITimeManager timeManager
            )
        {
            _timeManager = timeManager;
            _inputService = inputService;
        }

        private void Start()
        {
            _timeManager.ChangedTimeScale += SetAnimSpeed;
            SetAnimSpeed();
        }

        private void SetAnimSpeed()
        {
            legs1Animator.speed = Const1.AnimationSpeed * _timeManager.CurrentTimeScale;
        }

        private void Update()
        {
            SwitchAnimationState(_inputService, legs1Animator);
        }

        private void SwitchAnimationState(IInputService inputService, Animator legs1Anim)
        {
            if (inputService.GetMovementDirectionInput().magnitude > 0.2f)
                legs1Anim.SetBool(PlayerGo, true);
            else
            {
                legs1Anim.SetBool(PlayerGo, false);
            }
        }

        void OnDestroy()
        {
            _timeManager.ChangedTimeScale -= SetAnimSpeed;
        }
    }
}
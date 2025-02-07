using System;
using _2_NewBaseCode.BaseSceneCode._2_Sevices._1_SupportServices._1_Const;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.InputFol;
using _2_NewBaseCode.BaseSceneCode._2_Sevices.TimeModule;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.Level1.Entites._1_Player.Legs1
{
    public class PlayerAnimLegs1 : MonoBehaviour
    {
        private static readonly int PlayerGo = Animator.StringToHash("PlayerGo");
        [SerializeField] private Animator legs1Animator;
    
        private ITimeManager _timeManager;
        private IInputController _inputController;


        [Inject]
        void Construct(
            IInputController inputController,
            ITimeManager timeManager
            )
        {
            _inputController = inputController;
            _timeManager = timeManager;
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
            SwitchAnimationState(_inputController, legs1Animator);
        }

        private void SwitchAnimationState(IInputController inputServiceManager, Animator legs1Anim)
        {
            if (inputServiceManager.PlayerMoveDirection.magnitude > 0.2f)
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
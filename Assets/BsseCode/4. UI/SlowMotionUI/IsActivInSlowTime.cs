using BsseCode._2._Services.GlobalServices.TimeProvider;
using BsseCode._2._Services.LevelServices.TimeProvider;
using BsseCode._3._SupportCode.Constants;
using UnityEngine;
using Zenject;

namespace BsseCode._4._UI.SlowMotionUI
{
    public class IsActivInSlowTime : MonoBehaviour
    {
        [SerializeField] GameObject[] objectsToActivate;

        private ITimeModule _timeModule;

        [Inject]
        public void Construct(ITimeModule timeModule)
        {
            _timeModule = timeModule;
        }

        private void Start()
        {
            _timeModule.ChangeTimeScaleAction += Activate;
        }

        private void ChangeTimeScale()
        {
            _timeModule.SetNewTimeScale(Const.SlowTimeModificator);
        }


        private void Activate(float value)
        {
            bool isActive = !Mathf.Approximately(value, 1);

            foreach (var obj in objectsToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(isActive);
                }
            }
        }

        private void OnDestroy()
        {
            _timeModule.ChangeTimeScaleAction -= Activate;
        }
    }
}
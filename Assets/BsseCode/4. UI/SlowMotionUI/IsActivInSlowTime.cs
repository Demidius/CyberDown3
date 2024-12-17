using BsseCode._2._Services.GlobalServices.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode._4._UI.SlowMotionUI
{
    public class IsActivInSlowTime : MonoBehaviour
    {
        [SerializeField] GameObject[] objectsToActivate;

        private ITimeGlobalService _timeGlobalService;

        [Inject]
        public void Construct(ITimeGlobalService timeGlobalService)
        {
            _timeGlobalService = timeGlobalService;
        }

        private void Start()
        {
            _timeGlobalService.ChangeTimeScale += Activate;
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
            _timeGlobalService.ChangeTimeScale -= Activate;
        }
    }
}
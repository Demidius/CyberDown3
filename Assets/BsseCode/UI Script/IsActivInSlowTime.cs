using System;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace BsseCode.UI_Script
{
    public class IsActivInSlowTime : MonoBehaviour
    {
        [SerializeField] GameObject[] objectsToActivate;

        private ITimeService _timeService;

        [Inject]
        public void Construct(ITimeService timeService)
        {
            _timeService = timeService;
        }

        private void Start()
        {
            _timeService.ChangeTimeScale += Activate;
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
            _timeService.ChangeTimeScale -= Activate;
        }
    }
}
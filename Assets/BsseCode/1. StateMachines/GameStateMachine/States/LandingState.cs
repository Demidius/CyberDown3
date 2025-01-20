using System.Collections;
using _2_NewBaseCode.BaseSceneCode._1._GameMachine;
using _2_NewBaseCode.BaseSceneCode._2._Sevices._1._SupportServices.Coroutines;
using BsseCode._2._Services.ServiceLocator;
using BsseCode._3._SupportCode.Tags;
using UnityEngine;

namespace BsseCode._1._StateMachines.GameStateMachine.States
{
    public class LandingState : IGameState
    {
        
        private IGameMachineModule _gameMachineModule;
        private ICoroutineGlobalService _coroutineGlobalService;
        private GameObject _location;
        private IReusableServiceLocator _reusableServiceLocator;
        private IReusableServiceLocator _coroutineGlobalService1;

        public LandingState(
            IGameMachineModule gameMachineModule,
            IReusableServiceLocator reusableServiceLocator,
            IReusableServiceLocator coroutineGlobalService
            )
        {
            _coroutineGlobalService1 = coroutineGlobalService;
            _reusableServiceLocator = reusableServiceLocator;
            _gameMachineModule = gameMachineModule;
            _coroutineGlobalService = _reusableServiceLocator.CoroutineGlobalService;
        }
        public void Enter()
        {
            _reusableServiceLocator.PCInputGlobalService.OnGameplayState = true;
            Time.timeScale = 0.2f;
            _coroutineGlobalService.StartCoroutine(LandingTime());
            var _locationTemp = Object.FindObjectsOfType<LocationTag>();
            if (_locationTemp.Length > 0)
            {
                // Доступ к GameObject первого найденного компонента
                _location = _locationTemp[0].gameObject;

                Debug.Log($"Найден объект: {_location.name}");
            }
            else
            {
                Debug.LogError("Объект с компонентом LocationTag не найден!");
            }
            
            _location.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        private IEnumerator LandingTime()
        {
            float duration = 1f; // Длительность изменения масштаба
            float elapsedTime = 0f;

            Vector3 initialScale = _location.transform.localScale;
            Vector3 targetScale = Vector3.one; // Масштаб 1 по всем осям

            while (elapsedTime < duration)
            {
                // Плавно изменяем масштаб
                _location.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
                elapsedTime += Time.unscaledDeltaTime; // Используем unscaledDeltaTime, так как Time.timeScale = 0.2
                yield return null;
            }

            // Устанавливаем конечный масштаб точно
            _location.transform.localScale = targetScale;

            // Завершаем состояние
            _gameMachineModule.GameMachine.SetState(_gameMachineModule.GameplayState);
        }
        
        public void Exit()
        {
            Time.timeScale = 1f; 
            _reusableServiceLocator.PCInputGlobalService.OnGameplayState = false;
        }
    }
}
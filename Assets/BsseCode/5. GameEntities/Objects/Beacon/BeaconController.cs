using System.Collections;
using BaseCode2._2._Services.Coroutines;
using BsseCode._2._Services.GlobalServices.BeaconHandler;
using BsseCode._3._SupportCode.Constants;
using BsseCode._3._SupportCode.Tags;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Objects.Beacon
{
    public class BaseController : MonoBehaviour, IBaseController
    {
        [SerializeField] private GameObject greenBottom;
        [SerializeField] private GameObject redBottom;

        private float fillDuration = Const.BeaconFillDuration; 
        private Coroutine fillCoroutine;
        private bool isFilling;
        public bool IsFull { get; private set; } = false;
        private BeaconHandler _handler;
        private ICoroutineGlobalService _coroutineGlobalService;

        [Inject]
        public void Construct(BeaconHandler handler, ICoroutineGlobalService coroutineGlobalService)
        {
            _coroutineGlobalService = coroutineGlobalService;
            _handler = handler;
        }
        
        private void OnEnable()
        {
            ResetButton();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerTag>(out PlayerTag player))
            {
                if (!isFilling && !IsFull)
                {
                    fillCoroutine = _coroutineGlobalService.StartCoroutine(FillButton());
                }
            }
            else if (collision.TryGetComponent<_5._GameEntities.Objects.Enemy.Enemy>(out _5._GameEntities.Objects.Enemy.Enemy enemy))
            {
                if (isFilling && fillCoroutine != null && !IsFull)
                {
                    _coroutineGlobalService.StopCoroutine(fillCoroutine);
                    ResetButton();
                }
            }
        }
        
        private IEnumerator FillButton()
        {
            _handler.SetBaseController(this.transform.position);
            isFilling = true;

            greenBottom.SetActive(true);
            redBottom.SetActive(false);

            Vector3 originalScale = greenBottom.transform.localScale;
            Vector3 targetScale = originalScale;
            targetScale.x = 1f; // Полный масштаб по X

            // Устанавливаем начальный масштаб в 0 по оси X
            greenBottom.transform.localScale = new Vector3(0f, originalScale.y, originalScale.z);

            float elapsedTime = 0f;

            while (elapsedTime < fillDuration)
            {
                elapsedTime += Time.deltaTime;

                // Линейно интерполируем масштаб по оси X
                float progress = Mathf.Clamp01(elapsedTime / fillDuration);
                greenBottom.transform.localScale = new Vector3(progress * targetScale.x, originalScale.y, originalScale.z);

                yield return null;
            }

            // Устанавливаем окончательный масштаб
            greenBottom.transform.localScale = targetScale;

            _handler.OnFillingEnded();
            isFilling = false;
            IsFull = true;
        }



        private void ResetButton()
        {
            greenBottom.SetActive(false);
            redBottom.SetActive(true);
            isFilling = false;
            _handler.OnFillingEnded();
        }
    }

    public interface IBaseController
    {
    }
}

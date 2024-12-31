using System;
using BsseCode._3._SupportCode.Tags;
using BsseCode._5._GameEntities.Hero;
using UnityEngine;
using System.Collections;
using BsseCode._2._Services.GlobalServices.BasesHandler;
using Zenject;

namespace BsseCode._5._GameEntities.Objects
{
    public class BaseController : MonoBehaviour
    {
        [SerializeField] private GameObject greenBottom;
        [SerializeField] private GameObject redBottom;

        private float fillDuration = 30f; // Время заполнения
        private Coroutine fillCoroutine;
        private bool isFilling = false;
        private BasesHandler _handler;

        [Inject]
        public void Construct(BasesHandler handler)
        {
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
                if (!isFilling)
                {
                    fillCoroutine = StartCoroutine(FillButton());
                }
            }
            else if (collision.TryGetComponent<Enemy.Enemy>(out Enemy.Enemy enemy))
            {
                if (isFilling && fillCoroutine != null)
                {
                    StopCoroutine(fillCoroutine);
                    ResetButton();
                }
            }
        }
        
        private IEnumerator FillButton()
        {
            _handler.SetBaseController(this);
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
        }



        private void ResetButton()
        {
            greenBottom.SetActive(false);
            redBottom.SetActive(true);
            isFilling = false;
            _handler.OnFillingEnded();
        }
    }
}

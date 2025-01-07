using System.Collections;
using BsseCode._1._StateMachines.GameStateMachine;
using TMPro;
using UnityEngine;
using Zenject;

namespace BsseCode._4._UI.Level1UI
{
    public class ResetStatePanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countdownText;
        private GameMachineStarter _gameMachineStarter;

        [Inject]
        void Construct(GameMachineStarter gameMachineStarter)
        {
            _gameMachineStarter = gameMachineStarter;
        }

        public void OnEnable()
        {
            StartCoroutine(CountdownCoroutine());
        }

        private IEnumerator CountdownCoroutine()
        {
            Debug.Log("CountdownCoroutine ResetStatePanel");
            for (int i = 3; i >= 0; i--)
            {
                countdownText.text = i.ToString();
                yield return new WaitForSecondsRealtime(1f);
                Debug.Log(i.ToString());
            }
            Debug.Log("CountdownCoroutine ResetStatePanel");
            OnCountdownFinished();
        }

        private void OnCountdownFinished()
        { Debug.Log("CountdownCoroutine ResetStatePanel");
            _gameMachineStarter.ResetState.ReturnToGame();
        }
    }
}
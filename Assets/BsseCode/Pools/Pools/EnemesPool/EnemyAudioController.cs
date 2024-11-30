using System;
using BsseCode.Audio;
using BsseCode.ScriptablesObjects;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Zenject;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace BsseCode.Pools.Pools.EnemesPool
{
    public class EnemyAudioController : MonoBehaviour
    {
        private EventInstance _enemySteps;

        private void Start()
        {
            // _enemySteps = AudioManager.Instance.CreateInstance(FMODEvents.Instance.enemyStep);
        }

        private void Update()
        {
            _enemySteps.set3DAttributes(RuntimeUtils.To3DAttributes(transform));
        }

        private void OnEnable()
        {
            if (!_enemySteps.isValid())
            {
                // _enemySteps = AudioManager.Instance.CreateInstance(FMODEvents.Instance.enemyStep);
            }

            PLAYBACK_STATE playbackState;
            _enemySteps.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                _enemySteps.start();
            }
        }

        private void OnDisable()
        {
            if (_enemySteps.isValid())
            {
                _enemySteps.stop(STOP_MODE.ALLOWFADEOUT);
                _enemySteps.release(); 
            }
        }
        

      
    }
}
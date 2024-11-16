using System;
using BsseCode.Audio;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace BsseCode.Pools.Pools.EnemesPool
{
    public class EnemyAudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSourceBlades;
        [SerializeField] private AudioSource audioSourceStaps;


        protected ISoundsExplorer SoundsExplorer;
        protected SoundStorage SoundStorage;
       
        [Inject]
        public void Construct(ISoundsExplorer soundsExplorer, SoundStorage soundStorage, ITimeService timeService)
        {
           SoundStorage = soundStorage;
            SoundsExplorer = soundsExplorer;
        }

        private void OnEnable()
        {
            PlayStep();
            PlayBlades();
        }

        private void OnDisable()
        {
            SoundsExplorer.PlaySoundWhile(SoundStorage.Blades, audioSourceBlades, false);
            SoundsExplorer.PlayRandomSoundWhile(SoundStorage.Steps2, audioSourceStaps, false);
        }

        private void PlayBlades()
        {
            if (audioSourceBlades != null && !audioSourceBlades.enabled)
                audioSourceBlades.enabled = true;

            SoundsExplorer.PlaySoundWhile(SoundStorage.Blades, audioSourceBlades, true);
        }

        private void PlayStep()
        {
            if (audioSourceStaps != null && !audioSourceStaps.enabled)
                audioSourceStaps.enabled = true;

            SoundsExplorer.PlayRandomSoundWhile(SoundStorage.Steps2, audioSourceStaps, true, pitchMin: 1.0f, pitchMax: 1.5f);
        }
    }
}
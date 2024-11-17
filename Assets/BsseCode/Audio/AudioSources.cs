using System;
using BsseCode.Services.TimeProvider;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace BsseCode.Audio
{
    public abstract class AudioSources : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        protected ISoundsExplorer SoundsExplorer;
        protected SoundStorage SoundStorage;
       
        [Inject]
        public void Construct(ISoundsExplorer soundsExplorer, SoundStorage soundStorage)
        {
            SoundStorage = soundStorage;
            SoundsExplorer = soundsExplorer;
        }

        protected void SetAudioSource(AudioSource audioSource)
        {
            this.audioSource = audioSource;
        }
      
        protected AudioSource AudioSource()
        {
            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    Debug.LogWarning("AudioSource не найден на объекте!");
                }
            }
            return audioSource;
        }
    }
}
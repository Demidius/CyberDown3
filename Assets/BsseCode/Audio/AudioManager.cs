using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

namespace BsseCode.Audio
{
    public class AudioManager : MonoBehaviour
    {
        private List<EventInstance> eventInstances;
        public static AudioManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogWarning("More than one AudioManager in the scene!");
            }
            Instance = this;
            
            eventInstances = new List<EventInstance>();
        }


        public void PlayOneShot(EventReference sound, Vector3 worldPosition)
        {
            RuntimeManager.PlayOneShot(sound, worldPosition);
        }

        public EventInstance CreateInstance(EventReference eventReference)
        {
            EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
            eventInstances.Add(eventInstance);
            return eventInstance;
        }

        private void CleanUp()
        {
            foreach (EventInstance eventInstance in  eventInstances)
            {
                eventInstance.stop((FMOD.Studio.STOP_MODE.IMMEDIATE));
                eventInstance.release();
            }
        }

        private void OnDestroy()
        {
            CleanUp();
        }
    }
}
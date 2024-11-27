using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.Audio;

namespace BsseCode.ScriptablesObjects
{
    [CreateAssetMenu(fileName = "AudioTracksDate", menuName = "ScObj/AudioTracksDate")]
    public class AudioTracksDate : ScriptableObject
    {
        [EventRef]
        public EventReference shootTrack;
        
        [EventRef]
        public EventReference stepEvent;
        
    }

    
}
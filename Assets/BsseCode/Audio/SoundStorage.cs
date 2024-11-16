using UnityEngine;
using UnityEngine.Serialization;

namespace BsseCode.Audio
{
    [CreateAssetMenu(fileName = "SoundStorage", menuName = "Audio/Sound Storage")]
    public class SoundStorage: ScriptableObject
    {
        public AudioClip backgroundMusic;
        public AudioClip ShootGun;
        public AudioClip Step;
        public AudioClip Blades;
        
        public AudioClip[] Steps1;
        public AudioClip[] Steps2;
         public AudioClip stepsHero;
        
    }
}
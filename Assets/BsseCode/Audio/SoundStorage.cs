using UnityEngine;
using UnityEngine.Serialization;

namespace BsseCode.Audio
{
    [CreateAssetMenu(fileName = "SoundStorage", menuName = "Audio/Sound Storage")]
    public class SoundStorage: ScriptableObject
    {
        public AudioClip backgroundMusic;
        public AudioClip ShootGun;
        public AudioClip[] soundEffects;
        [FormerlySerializedAs("tepsHero")] [FormerlySerializedAs("StepsHero")] public AudioClip stepsHero;
        
    }
}
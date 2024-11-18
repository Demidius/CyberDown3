using UnityEngine;

namespace BsseCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SoundStorage", menuName = "ScriptableObjects/MyData")]
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
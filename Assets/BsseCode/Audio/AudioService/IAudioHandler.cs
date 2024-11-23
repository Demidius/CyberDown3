using BsseCode.Pools.Pools;
using UnityEngine;

namespace BsseCode.Audio.AudioService
{
    public interface IAudioHandler
    {
        public void AudioPlay(AudioClip Clip, Vector3 position, IPoolController poolController);
        public void AudioPlay(AudioClip[] audioClips, Vector3 position, IPoolController poolController);
    }
}
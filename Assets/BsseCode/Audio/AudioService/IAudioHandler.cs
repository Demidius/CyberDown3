using BsseCode.Pools.Pools;
using UnityEngine;
using UnityEngine.Audio;

namespace BsseCode.Audio.AudioService
{
    public interface IAudioHandler
    {
        public void AudioPlay(AudioClip Clip, AudioMixerGroup mixerGroup, Vector3 position, IPoolController poolController);
        public void AudioPlay(AudioClip[] audioClips, AudioMixerGroup mixerGroup, Vector3 position, IPoolController poolController);
    }
}
// using System;
// using BsseCode.Pools.Pools;
// using BsseCode.Pools.Pools.SourceSours;
// using FMODUnity;
// using UnityEngine;
// using Zenject;
//
// namespace BsseCode.Audio
// {
//     public class AudioExplorer : IAudioExplorer
//     {
//        
//         public void PlayOneSound(EventReference trackEvent, Vector3 position, IPoolController poolController)
//         {
//             var sound = poolController.GetPool<AudioSource2>().GetElement();
//             sound.SetParameters(trackEvent, position);
//         }
//     }
//
//     public interface IAudioExplorer
//     {
//         public void PlayOneSound(EventReference trackEvent, Vector3 position, IPoolController poolController);
//     }
// }
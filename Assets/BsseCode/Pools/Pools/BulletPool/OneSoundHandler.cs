using System.Collections;
using BsseCode.Audio;
using BsseCode.Caracters.Hero;
using BsseCode.Services.Coroutines;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.BulletPool
{
    public class OneSoundHandler
    {
        // private readonly SoundStorage _soundStorage;
        // private Coroutine _audioCoroutine;
        // private ISoundsExplorer _soundsExplorer;
        // private IPoolController _poolController;
        // private ICoroutineService _coroutineService;
        // private Player _player;
        // private IPoolController _poolController1;
        //
        //
        // [Inject]
        // public void Construct( ICoroutineService coroutineService, ISoundsExplorer soundsExplorer, Player player, IPoolController poolController)
        // {
        //     _poolController1 = poolController;
        //     _player = player;
        //     _coroutineService = coroutineService;
        //     _soundsExplorer = soundsExplorer;
        // }
        //
        //
        // public void PlayShoot(Vector3 position, AudioClip sound, IPoolController poolController)
        // {
        //     _poolController = poolController;
        //     var audioElement = GetAudioElementFromPool();
        //     if (audioElement == null) return;
        //
        //     var sourceAudio = audioElement.GetComponent<AudioSource>();
        //     if (sourceAudio == null)
        //     {
        //         Debug.LogError("AudioSource component is missing on the audio element.");
        //         return;
        //     }
        //
        //     sourceAudio.transform.position = position;
        //     
        //     if (sound == null || sourceAudio == null) return;
        //     
        //     sourceAudio.pitch = _soundsExplorer.TineScaleForAudio();
        //     sourceAudio.PlayOneShot(sound);
        //     StartAudioReturnRoutine(audioElement, sourceAudio);
        // }
        //
        // private SoursSound GetAudioElementFromPool() =>
        //     _poolController.GetPool<SoursSound>()?.GetElement();
        //
        // private void StartAudioReturnRoutine(SoursSound audioElement, AudioSource sourceAudio)
        // {
        //     StopAudioReturnRoutine();
        //     _audioCoroutine = _coroutineService?.StartCoroutine(AudioReturnRoutine(audioElement, sourceAudio));
        // }
        //
        // private void StopAudioReturnRoutine()
        // {
        //     if (_audioCoroutine != null)
        //     {
        //         _coroutineService?.StopCoroutine(_audioCoroutine);
        //         _audioCoroutine = null;
        //     }
        // }
        //
        // private IEnumerator AudioReturnRoutine(SoursSound audioElement, AudioSource sourceAudio)
        // {
        //     yield return new WaitWhile(() => sourceAudio.isPlaying);
        //     audioElement.Deactivate();
        //     _audioCoroutine = null;
        // }
    }
}
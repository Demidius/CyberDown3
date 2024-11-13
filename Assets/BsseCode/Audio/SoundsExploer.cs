using System.Collections;
using BsseCode.Services.Coroutines;
using UnityEngine;

namespace BsseCode.Audio
{
    public class SoundsExplorer : ISoundsExplorer
    {

        private readonly ICoroutineService _coroutineService;

        public SoundsExplorer(ICoroutineService coroutineService)
        {
            _coroutineService = coroutineService;
        }

        // Воспроизведение случайного звука из массива
        public void PlayRandomSoundFrom(AudioClip[] clips, AudioSource audioSource,
            float volume = 1.0f,
            float pitchMin = 1.0f,
            float pitchMax = 1.0f)
        {
            if (clips == null || clips.Length == 0 || audioSource == null) return;

            AudioClip selectedClip = clips[Random.Range(0, clips.Length)];
            audioSource.volume = volume;
            audioSource.pitch = pitchMin != pitchMax ? Random.Range(pitchMin, pitchMax) : pitchMin;
            audioSource.PlayOneShot(selectedClip);
            audioSource.pitch = 1.0f;
        }


        // Воспроизведение конкретного звука
        public void PlaySoundFrom(AudioClip clip, AudioSource audioSource)
        {
            if (clip == null || audioSource == null) return;

            audioSource.PlayOneShot(clip);
        }

        // Воспроизведение массива звуков поочерёдно
        public void PlayClipsInSequence(AudioClip[] clips, AudioSource audioSource)
        {
            if (clips == null || clips.Length == 0 || audioSource == null) return;

            _coroutineService.StartCoroutine(PlayClipsSequentially(clips, audioSource));
        }

        // Короутина для поочередного воспроизведения звуков
        private IEnumerator PlayClipsSequentially(AudioClip[] clips, AudioSource audioSource)
        {
            foreach (var clip in clips)
            {
                audioSource.clip = clip;
                audioSource.Play();

                // Ждём, пока текущий клип завершится
                yield return new WaitForSeconds(clip.length);
            }
        }

        // Воспроизведение звука повторно, пока выполняется условие
        public void PlaySoundWhile(AudioClip clip, AudioSource audioSource, System.Func<bool> condition)
        {
            if (clip == null || audioSource == null || condition == null) return;

            _coroutineService.StartCoroutine(PlaySoundRepeatedly(clip, audioSource, condition));
        }

        // Короутина для повторного воспроизведения звука при выполнении условия
        private IEnumerator PlaySoundRepeatedly(AudioClip clip, AudioSource audioSource, System.Func<bool> condition)
        {
            while (condition())
            {
                audioSource.clip = clip;
                audioSource.Play();

                // Ждем завершения текущего клипа перед повтором
                yield return new WaitForSeconds(clip.length);
            }

        }
    }


    public interface ISoundsExplorer
    {
        public void PlayRandomSoundFrom(AudioClip[] clips, AudioSource audioSource, 
            float volume = 1.0f, 
            float pitchMin = 1.0f, 
            float pitchMax = 1.0f);
        public void PlaySoundFrom(AudioClip clipName, AudioSource audioSource);
        public void PlayClipsInSequence(AudioClip[] clipName, AudioSource audioSource);
        public void PlaySoundWhile(AudioClip clip, AudioSource audioSource, System.Func<bool> condition);
    }
}
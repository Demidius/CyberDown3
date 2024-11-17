using System.Collections;
using BsseCode.Services.Coroutines;
using BsseCode.Services.TimeProvider;
using UnityEngine;

namespace BsseCode.Audio
{
    public class SoundsExplorer : ISoundsExplorer
    {
        private readonly ICoroutineService _coroutineService;
        private readonly ITimeService _timeService;
        private Coroutine _activeCoroutine;

        public SoundsExplorer(ICoroutineService coroutineService, ITimeService timeService)
        {
            _coroutineService = coroutineService;
            _timeService = timeService;
        }

        private float TineScaleForAudio() => Mathf.Clamp(_timeService.TimeScale, 0.6f, 1.0f);

        // Воспроизведение случайного звука из массива
        public void PlayRandomSoundFrom(AudioClip[] clips, AudioSource audioSource,
            float volume = 1.0f,
            float pitchMin = 1.0f,
            float pitchMax = 1.0f)
        {
            if (clips == null || clips.Length == 0 || audioSource == null) return;

            AudioClip selectedClip = clips[Random.Range(0, clips.Length)];
            audioSource.volume = volume;

            float basePitch = pitchMin != pitchMax ? Random.Range(pitchMin, pitchMax) : pitchMin;
            audioSource.pitch = basePitch * TineScaleForAudio();
            audioSource.PlayOneShot(selectedClip);
        }

        // Воспроизведение конкретного звука
        public void PlaySoundFrom(AudioClip clip, AudioSource audioSource)
        {
            if (clip == null || audioSource == null) return;

            audioSource.pitch = TineScaleForAudio();
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
                audioSource.pitch = TineScaleForAudio();
                audioSource.clip = clip;
                audioSource.Play();

                // Ждём, пока текущий клип завершится с учётом изменённого pitch
                yield return new WaitForSeconds(clip.length / audioSource.pitch);
            }
        }

        // Воспроизведение звука повторно, пока выполняется условие
        public void PlaySoundWhile(AudioClip clip, AudioSource audioSource, bool condition)
        {
            if (clip == null || audioSource == null) return;

            if (condition)
            {
                _activeCoroutine =
                    _coroutineService.StartCoroutine(PlaySoundRepeatedly(clip, audioSource));
            }
            else
            {
                if (_activeCoroutine != null)
                {
                    _coroutineService.StopCoroutine(_activeCoroutine);
                    _activeCoroutine = null;
                }
            }
        }

        // Короутина для повторного воспроизведения звука при выполнении условия
        private IEnumerator PlaySoundRepeatedly(AudioClip clip, AudioSource audioSource)
        {
            while (true)
            {
                audioSource.pitch = TineScaleForAudio();
                audioSource.clip = clip;
                audioSource.Play();

                // Ждём завершения текущего клипа с учётом pitch
                yield return new WaitForSeconds(clip.length / audioSource.pitch);
            }
        }

        public void PlayRandomSoundWhile(AudioClip[] clips, AudioSource audioSource, bool condition,
            float pitchMin = 1.0f,
            float pitchMax = 1.0f)
        {
            if (clips == null || clips.Length == 0 || audioSource == null)
            {
                Debug.LogWarning("Некорректные параметры: массив клипов пустой или AudioSource не задан.");
                return;
            }

            if (!audioSource.gameObject.activeInHierarchy || !audioSource.enabled)
            {
                Debug.LogWarning("AudioSource не активен или отключён.");
                return;
            }

            float basePitch = pitchMin != pitchMax ? Random.Range(pitchMin, pitchMax) : pitchMin;

            if (condition)
            {
                if (_activeCoroutine == null)
                {
                    _activeCoroutine =
                        _coroutineService.StartCoroutine(PlayRandomSoundRepeatedly(clips, audioSource, basePitch));
                }
            }
            else
            {
                if (_activeCoroutine != null)
                {
                    _coroutineService.StopCoroutine(_activeCoroutine);
                    _activeCoroutine = null;
                }
            }
        }
        private IEnumerator PlayRandomSoundRepeatedly(AudioClip[] clips, AudioSource audioSource, float basePitch)
        {
            while (true)
            {
                if (audioSource == null || !audioSource.gameObject.activeInHierarchy || !audioSource.enabled)
                {
                    Debug.LogWarning("AudioSource неактивен или отключён. Завершаем воспроизведение.");
                    yield break;
                }
               
                AudioClip selectedClip = clips[Random.Range(0, clips.Length)];
                audioSource.pitch = TineScaleForAudio() * basePitch;
                audioSource.clip = selectedClip;
                audioSource.Play();
                
                yield return new WaitForSeconds(selectedClip.length / audioSource.pitch);
            }
        }

       
    }

    public interface ISoundsExplorer
    {
        void PlayRandomSoundFrom(AudioClip[] clips, AudioSource audioSource,
            float volume = 1.0f,
            float pitchMin = 1.0f,
            float pitchMax = 1.0f);

        void PlaySoundFrom(AudioClip clip, AudioSource audioSource);
        void PlayClipsInSequence(AudioClip[] clips, AudioSource audioSource);
        void PlaySoundWhile(AudioClip clip, AudioSource audioSource, bool condition);

        public void PlayRandomSoundWhile(AudioClip[] clips, AudioSource audioSource, bool condition,
            float pitchMin = 1.0f,
            float pitchMax = 1.0f);
    }
}
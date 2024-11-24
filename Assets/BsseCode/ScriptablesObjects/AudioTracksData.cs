using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace BsseCode.ScriptablesObjects
{
    [System.Serializable]
    public class AudioTrack
    {
        public string trackName; // Название трека
        public AudioClip clip; // Аудиоклип
        public AudioMixerGroup mixerGroup; // Группа микшера
    }

    [CreateAssetMenu(fileName = "AudioTracksData", menuName = "Audio/Audio Tracks Data", order = 1)]
    public class AudioTracksData : ScriptableObject
    {
        public List<AudioTrack> tracks = new List<AudioTrack>(); // Список аудиотреков

        private Dictionary<string, AudioTrack> trackDictionary;

        // Инициализация словаря для быстрого доступа к трекам
        public void Initialize()
        {
            trackDictionary = new Dictionary<string, AudioTrack>();
            foreach (var track in tracks)
            {
                if (!string.IsNullOrEmpty(track.trackName))
                {
                    if (!trackDictionary.ContainsKey(track.trackName))
                    {
                        trackDictionary.Add(track.trackName, track);
                    }
                    else
                    {
                        Debug.LogWarning($"Трек с названием '{track.trackName}' уже существует в списке!");
                    }
                }
            }
        }

        // Получить трек по названию
        public AudioTrack GetTrackByName(string name)
        {
            if (trackDictionary == null)
            {
                Initialize(); // Инициализируем словарь, если он ещё не создан
            }

            if (trackDictionary.TryGetValue(name, out var track))
            {
                return track;
            }

            Debug.LogError($"Трек с названием '{name}' не найден!");
            return null;
        }

        // Получить микшерную группу по названию трека
        public AudioMixerGroup GetMixerByTrackName(string name)
        {
            var track = GetTrackByName(name);
            if (track != null)
            {
                return track.mixerGroup;
            }

            Debug.LogError($"Микшер для трека с названием '{name}' не найден!");
            return null;
        }
    }
}
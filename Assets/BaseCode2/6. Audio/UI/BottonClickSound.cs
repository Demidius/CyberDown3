using BaseCode2._6._Audio.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace BaseCode2._6._Audio.UI
{
    public class BottonClickSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private AudioManager _audioManager;
        private AudioTracksBase _audioTracks;

        [Inject]
        void Construct(AudioManager audioManager, AudioTracksBase audioTracks)
        {
            _audioTracks = audioTracks;
            _audioManager = audioManager;
        }
        
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            _audioManager.PlaySound(_audioTracks.click1Sound);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _audioManager.PlaySound(_audioTracks.click3Sound);

        }
    }
}
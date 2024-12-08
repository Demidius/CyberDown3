using UnityEngine;
using UnityEngine.UI;

namespace BsseCode._6._Audio.Managers
{
    public class AudioVolumeController : MonoBehaviour
    {
        private float _currentVolume = 0.5f;

        private const float SmoothSpeed = 4.0f;
        private float VolumeScale;
        [SerializeField] private Slider VolumeSlider;

        private void Awake()
        {
            VolumeSlider.value = _currentVolume;
        }
        
        private void Update()
        { 
            if (VolumeSlider == null)
            {
                Debug.LogWarning("VolumeSlider is not assigned!");
                return;
            }
            _currentVolume = Mathf.Lerp(_currentVolume, VolumeSlider.value, Time.deltaTime * SmoothSpeed);
            SetVolume(_currentVolume);
        }

        private void SetVolume(float speed)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GlobalVolume", speed);
        }
    }
}
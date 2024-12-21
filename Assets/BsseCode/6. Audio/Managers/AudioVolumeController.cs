using UnityEngine;
using UnityEngine.UI;

namespace BsseCode._6._Audio.Managers
{
    public class AudioVolumeController : MonoBehaviour
    {
        private float _currentVolume = 0.5f;
        private const float SmoothSpeed = 42.0f;
        private bool _isSliderChanged; 
        [SerializeField] private Slider VolumeSlider;

        private void Awake()
        {
            if (VolumeSlider != null)
            {
                VolumeSlider.value = _currentVolume;
                VolumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
            }
        }

        private void Update()
        {
            if (VolumeSlider == null)
            {
                Debug.LogWarning("VolumeSlider is not assigned!");
                return;
            }

            FMODUnity.RuntimeManager.StudioSystem.getParameterByName("GlobalVolume", out float externalVolume);

            if (!_isSliderChanged)
            {
                _currentVolume = Mathf.Lerp(_currentVolume, externalVolume, Time.deltaTime * SmoothSpeed);
                VolumeSlider.value = _currentVolume;
            }

            _isSliderChanged = false;
        }

        private void OnSliderValueChanged(float value)
        {
            _isSliderChanged = true;
            _currentVolume = value;
            SetVolume(_currentVolume);
        }

        private void SetVolume(float volume)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GlobalVolume", volume);
        }
    }
}
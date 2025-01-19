using UnityEngine;
using UnityEngine.UI;

namespace NewBaseCode._4._Audio.Managers
{
    public class AudioVolumeController : MonoBehaviour
    {
        private float _currentVolume = 0.5f;
        private const float SmoothSpeed = 42.0f;
        private bool _isSliderChanged; 
        [SerializeField] private Slider VolumeSlider;

        private const string VolumePrefKey = "GlobalVolume"; // Ключ для сохранения в PlayerPrefs

        private void Awake()
        {
            // Загрузка сохранённого значения громкости
            if (PlayerPrefs.HasKey(VolumePrefKey))
            {
                _currentVolume = PlayerPrefs.GetFloat(VolumePrefKey);
            }

            if (VolumeSlider != null)
            {
                VolumeSlider.value = _currentVolume;
                VolumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
            }

            // Установка начального значения громкости
            SetVolume(_currentVolume);
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

            // Сохранение значения громкости
            PlayerPrefs.SetFloat(VolumePrefKey, _currentVolume);
            PlayerPrefs.Save();
        }

        private void SetVolume(float volume)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GlobalVolume", volume);
        }
    }
}

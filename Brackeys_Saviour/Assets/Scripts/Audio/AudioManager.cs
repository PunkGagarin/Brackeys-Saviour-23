using UnityEngine;
using UnityEngine.UI;

namespace Audio {
    public class AudioManager : MonoBehaviour {
        [SerializeField] 
        private AudioSource _bgAudioSource;
        
        [SerializeField] 
        private AudioSource _soundEffectAudioSource;

        [SerializeField] 
        private Slider _volumeSlider;
        
        [SerializeField] 
        private AudioClip _bgSound;
        
        [SerializeField] 
        private AudioClip _btnSound;

        private void Start() {
            PlayBgSound();

            if (PlayerPrefs.HasKey("volume")) {
                var volume = PlayerPrefs.GetFloat("volume");
                _bgAudioSource.volume = volume;
                _soundEffectAudioSource.volume = volume;
            }
            
            if (_volumeSlider != null) {
                _volumeSlider.onValueChanged.AddListener(ChangeVolume);
                _volumeSlider.value = _bgAudioSource.volume;
            }
        }

        private void ChangeVolume(float value) {
            PlayerPrefs.SetFloat("volume", value);
            PlayerPrefs.Save();
            
            _bgAudioSource.volume = value;
            _soundEffectAudioSource.volume = value;
        }

        private void PlayBgSound() {
            _bgAudioSource.clip = _bgSound;
            _bgAudioSource.Play();
        }
        
        private void PlaySound() {
            //_soundEffectAudioSource.clip = ...;
            //_soundEffectAudioSource.Play();
        }
        
        public void PlayButtonSound() {
            _soundEffectAudioSource.clip = _btnSound;
            _soundEffectAudioSource.Play();
        }
    }
}
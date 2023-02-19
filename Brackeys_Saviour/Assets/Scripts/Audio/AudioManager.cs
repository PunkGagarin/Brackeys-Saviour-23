using UnityEngine;
using UnityEngine.UI;

namespace Audio {
    public class AudioManager : MonoBehaviour {
        [SerializeField] 
        private AudioSource _bgAudioSource;
        
        [SerializeField] 
        private AudioSource _soundEffectAudioSource;

        [SerializeField] 
        private AudioClip _bgSound;

        [SerializeField] 
        private Slider _volumeSlider;

        private void Start() {
            PlayBgSound();

            _volumeSlider.onValueChanged.AddListener(ChangeVolume);

            if (PlayerPrefs.HasKey("volume")) {
                var volume = PlayerPrefs.GetFloat("volume");
                _bgAudioSource.volume = volume;
                _soundEffectAudioSource.volume = volume;
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
        
    }
}
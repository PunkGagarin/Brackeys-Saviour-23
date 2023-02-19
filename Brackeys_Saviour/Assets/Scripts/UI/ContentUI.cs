using Audio;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace UI {

    public class ContentUI : MonoBehaviour {

        protected GameObject _content;

        [Inject]
        private AudioManager _audioManager;

        protected virtual void Awake() {
            _content = transform.Find("Content").gameObject;
            Assert.IsNotNull(_content);
        }

        public virtual void ShowContent() {
            _audioManager.PlayEffectSound("snd_ui_book_open");
            if (_content != null) {
                _content.SetActive(true);
            }
        }
        
        public virtual void HideContent() {
            _audioManager.PlayEffectSound("snd_ui_book_close");
            _content.SetActive(false);
        }
        
    }

}
using UnityEngine;
using UnityEngine.Assertions;

namespace UI {

    public class ContentUI : MonoBehaviour {

        protected GameObject _content;

        private void Awake() {
            _content = transform.Find("Content").gameObject;
            Assert.IsNotNull(_content);
        }

        public virtual void ShowContent() {
            _content.SetActive(true);
        }
        
        public virtual void HideContent() {
            _content.SetActive(false);
        }
        
    }

}
using System;
using ModestTree;
using UnityEngine;
using UnityEngine.UI;

namespace Events.UI {

    public class ContinueButton : MonoBehaviour {

        private Button _button;

        public Action<int> OnButtonClick = delegate { };

        [field: SerializeField]
        public int index { get; set; }

        public Button.ButtonClickedEvent onClick {
            get {
                FindButtonComponent();
                return _button.onClick;
            }
            set => _button.onClick = value;
        }

        void Awake() {
            FindButtonComponent();
            Assert.IsNotNull(_button);
        }

        private void FindButtonComponent() {
            _button = GetComponent<Button>();
        }

    }

}
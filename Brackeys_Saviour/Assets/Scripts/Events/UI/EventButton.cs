using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Events.UI {

    [RequireComponent(typeof(Button))]
    public class EventButton : MonoBehaviour {

        private Button _button;

        public event Action Clicked {
            add => _button.clicked += value;
            remove => _button.clicked -= value;
        }

        private void Awake() {
            _button = GetComponent<Button>();
        }

        public void SetButtonText(string text) {
            _button.text = text;
        }
    }

}
using System;
using ModestTree;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Events.UI {

    public class ChoiceButton : MonoBehaviour {

        private TextMeshProUGUI _textMeshProUGUI;

        private Button _button;

        public Action<int> OnButtonClick = delegate { };

        [field: SerializeField]
        public int index { get; set; }

        private void Awake() {
            FindButtonComponent();
            _button.onClick.AddListener(InvokeOnClick);
        }

        public void FindButtonComponent() {
            _button = GetComponent<Button>();
            Assert.IsNotNull(_button);
            _textMeshProUGUI = _button.GetComponentInChildren<TextMeshProUGUI>(true);
        }

        private void InvokeOnClick() {
            OnButtonClick.Invoke(index);
        }

        public void ChangeButtonText(string choiceText) {
            _textMeshProUGUI.text = choiceText;
        }

    }

}
using UnityEngine;
using UnityEngine.UI;

namespace Events {

    public class EventPopupUI : MonoBehaviour {
        [SerializeField] private Button _button;

        public Button button {
            get => GetComponent<Button>();
            private set => _button = value;
        }

        private void Awake() {
            button = GetComponent<Button>();
        }

    }

}
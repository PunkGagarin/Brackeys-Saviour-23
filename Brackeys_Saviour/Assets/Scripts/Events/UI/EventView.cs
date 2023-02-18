using Events.GameEvents;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Events.UI {

    public class EventView : ContentUI {

        private const string DefaultAcceptText = "Accept";
        private const string DefaultRejectText = "Reject";

        private BaseGameEvent _currentEvent;

        // private int _currentEventTimer;

        [SerializeField]
        private TextMeshProUGUI _eventText;

        [SerializeField]
        private Button _acceptButton;

        [SerializeField]
        private Button _rejectButton;

        [SerializeField]
        private Button _afterEventButton;

        // [Header("Timer")]
        // [SerializeField]
        // private TextMeshProUGUI _timerText;

        // [SerializeField]
        // private int _eventTimer;

        // private List<EventButton> _eventButtons;


        private void Awake() {
            // _acceptButton.onClick.AddListener(AcceptEvent);
            // _rejectButton.onClick.AddListener(RejectEvent);
            // _afterEventButton.onClick.AddListener(HideContent);
        }


        private void AcceptEvent() {
            HideButtons();

            _currentEvent.Apply();
            ShowEventText(_currentEvent.acceptedText);
        }

        private void ShowEventText(string currentEventText) {
            _eventText.text = currentEventText;
        }

        private void RejectEvent() {
            HideButtons();

            _currentEvent.Reject();
            ShowEventText(_currentEvent.rejectedText);
        }

        public void UpdateUiForEvent(BaseGameEvent baseGameEvent) {
            ShowContent();
            ShowButtons();
            _currentEvent = baseGameEvent;

            _eventText.text = baseGameEvent.gameEventText;
            if (baseGameEvent.acceptButtonText != null) {
                _acceptButton.GetComponentInChildren<TextMeshProUGUI>().text = baseGameEvent.acceptButtonText;
            }
            if (baseGameEvent.rejectButtonText != null) {
                _rejectButton.GetComponentInChildren<TextMeshProUGUI>().text = baseGameEvent.rejectButtonText;
            }

            // if (_timerText != null) {
            //     _currentEventTimer = _eventTimer;
            //     StartCoroutine(StartEventTimer());
            // }
        }

        private void ShowButtons() {
            // _acceptButton.gameObject.SetActive(true);
            // _rejectButton.gameObject.SetActive(true);
            // ShowOkayButton();
        }

        private void HideButtons() {
            // StopAllCoroutines();
            // SetDefaultButtonsText();
            // _acceptButton.gameObject.SetActive(false);
            // _rejectButton.gameObject.SetActive(false);
            // ShowOkayButton();
        }


        // private IEnumerator StartEventTimer() {
        //     while (_currentEventTimer > 0) {
        //         yield return new WaitForSeconds(1f);
        //         _currentEventTimer--;
        //         _timerText.text = _currentEventTimer.ToString();
        //     }
        //     ChooseRandomOption();
        // }

        private void ChooseRandomOption() {
            int rnd = Random.Range(0, 2);
            // if (rnd == 0) {
            //     AcceptEvent();
            // } else {
            //     RejectEvent();
            // }
        }

        private void SetDefaultButtonsText() {
            // _acceptButton.GetComponentInChildren<TextMeshProUGUI>().text = DefaultAcceptText;
            // _acceptButton.GetComponentInChildren<TextMeshProUGUI>().text = DefaultRejectText;
        }

        private void ShowOkayButton() {
            // _afterEventButton.gameObject.SetActive(true);
        }

        private void OnDestroy() {
            // _acceptButton.onClick.RemoveAllListeners();
            // _rejectButton.onClick.RemoveAllListeners();
        }
    }

}
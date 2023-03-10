using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using ModestTree;
using SpiritResources;
using TMPro;
using UI;
using UI.BreatheGame;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace Events.UI {

    public class GameEventUI : ContentUI {
        private const string Eventname = "EventName";

        private Story _story;

        private List<Choice> _currentChoices;

        private ContinueButton _continueButton;

        private List<ChoiceButton> _choiceButtons;

        private float _currentTimer;

        private bool _isTimerActive;

        [Inject]
        private MiniGameUI _miniGameUI;

        [SerializeField]
        private TextMeshProUGUI _mainStoryText;

        [SerializeField]
        private TextMeshProUGUI _addResourcesText;

        [SerializeField]
        private TextMeshProUGUI _headerText;

        [SerializeField]
        private Image _eventImage;

        [Header("Timer")]
        [SerializeField]
        private Image _timerImage;

        [SerializeField]
        private float _timeToDecide = 25f;

        [SerializeField]
        private GameObject _timerPanel;

        private const string MoneyTag = "Money";

        private const string VolunteersTag = "Volunteers";

        private const string HappinessTag = "Happiness";

        private const string MiniGameTag = "MiniGame";


        public Action OnEventFinished = delegate { };
        public Action<SpiritResourceType, int> OnResourceTagInput = delegate { };

        protected override void Awake() {
            base.Awake();
            Assert.IsNotNull(_mainStoryText);
            Assert.IsNotNull(_headerText);
            Assert.IsNotNull(_eventImage);
            Assert.IsNotNull(_timerImage);
            Assert.IsNotNull(_timerPanel);
        }

        private void Start() {
            _choiceButtons = GetComponentsInChildren<ChoiceButton>(true).ToList();
            _continueButton = GetComponentInChildren<ContinueButton>(true);

            Assert.IsNotNull(_choiceButtons);
            Assert.IsNotNull(_continueButton);

            foreach (var btn in _choiceButtons) {
                btn.OnButtonClick += MakeChoice;
                btn.FindButtonComponent();
            }
            _continueButton.onClick.AddListener(ContinueStory);
        }

        private void Update() {
            if (!_isTimerActive) return;

            if (_currentTimer <= 0) {
                MakeRandomChoice();
                TurnOffTimer();
                _currentTimer = _timeToDecide;
            } else {
                _currentTimer -= Time.deltaTime;
                _timerImage.fillAmount = _currentTimer / _timeToDecide;
            }
        }


        // private void UpdateTimer() {
        //     _timerImage.fillAmount = _timeToDecide / _currentTimer;
        // }

        private void MakeRandomChoice() {
            MakeChoice(Random.Range(0, _story.currentChoices.Count));
        }


        #region OnDestroy

        private void OnDestroy() {
            foreach (var btn in _choiceButtons) {
                btn.OnButtonClick -= MakeChoice;
            }
            _continueButton.onClick.RemoveAllListeners();
        }

        #endregion

        private void MakeChoice(int btnIndex) {
            _story.ChooseChoiceIndex(btnIndex);
            ContinueStory();
        }

        public void HandleStory(TextAsset storyJson) {
            ShowContent();
            _story = new Story(storyJson.text);
            ParseHeader();
            ContinueStory();
        }

        private void ParseHeader() {
            var storyGlobalTags = _story.globalTags;
            var eventNameTag = storyGlobalTags?.FirstOrDefault(el => el.Contains(Eventname));
            if (eventNameTag != null) {
                // var eventNameValue = EventNameTag.Split(":")[1].Trim();
                _headerText.text = eventNameTag.Split(":")[1].Trim();
            } else {
                _headerText.text = "Here is my story...";
                Debug.LogError(new Exception("There is no global tag with EventName!!"));
            }
            _eventImage.sprite = EventImageFactory.GetProperImageForStory(_headerText.text);
        }

        private IEnumerator ShowRes(string text) {
            yield return new WaitForSeconds(2f);
            _addResourcesText.gameObject.SetActive(true);
            _addResourcesText.text = text;
            yield return new WaitForSeconds(2f);
            _addResourcesText.gameObject.SetActive(false);
        }

        private void ContinueStory() {
            _currentTimer = _timeToDecide;

            if (_story.canContinue) {
                _mainStoryText.text = _story.Continue();
                _currentChoices = _story.currentChoices;
                ProceedChoices();
                ProceedGameTags();
            } else {
                ExitDialogue();
            }
        }

        private void ProceedGameTags() {
            foreach (string tag in _story.currentTags) {
                string[] splitTag = tag.Split(":");

                if (splitTag.Length != 2) {
                    Debug.LogError("Cant parse tag properly!");
                }
                string tagKey = splitTag[0].Trim();
                string tagValue = splitTag[1].Trim();

                switch (tagKey) {
                    case MoneyTag:
                        HandleTagChange(SpiritResourceType.Money, int.Parse(tagValue));
                        Debug.Log("Money game tag: " + tagValue);
                        StartCoroutine(ShowRes("Money game tag: " + tagValue));
                        break;
                    case VolunteersTag:
                        Debug.Log("Volunteers game tag : " + tagValue);
                        StartCoroutine(ShowRes("Volunteers game tag : " + tagValue));
                        HandleTagChange(SpiritResourceType.Volunteers, int.Parse(tagValue));
                        break;
                    case "Volunteer":
                        Debug.Log("Volunteers game tag : " + tagValue);
                        StartCoroutine(ShowRes("Volunteers game tag : " + tagValue));
                        HandleTagChange(SpiritResourceType.Volunteers, int.Parse(tagValue));
                        break;
                    case HappinessTag:
                        Debug.Log("Happiness game tag : " + tagValue);
                        StartCoroutine(ShowRes("Happiness game tag : " + tagValue));
                        HandleTagChange(SpiritResourceType.Happiness, int.Parse(tagValue));
                        break;
                    case MiniGameTag:
                        _miniGameUI.ShowContent();
                        break;
                    default:
                        // Debug.Log("Not supported or not a game tag : " + tagKey);
                        break;
                }
            }
        }

        private void HandleTagChange(SpiritResourceType type, int value) {
            OnResourceTagInput(type, value);
        }

        private void ProceedChoices() {
            if (_currentChoices.Count <= 0) {
                DisplayContinueButton();
                return;
            }

            HideContinueButton();
            TurnOnTimer();

            for (int i = 0; i < _choiceButtons.Count; i++) {
                if (_currentChoices.Count > i) {
                    _choiceButtons[i].gameObject.SetActive(true);
                    _choiceButtons[i].ChangeButtonText(_currentChoices[i].text);
                } else {
                    _choiceButtons[i].gameObject.SetActive(false);
                }
            }
        }

        private void DisplayContinueButton() {
            foreach (var btn in _choiceButtons) {
                btn.gameObject.SetActive(false);
            }
            _continueButton.gameObject.SetActive(true);
            TurnOffTimer();
        }

        private void TurnOnTimer() {
            _isTimerActive = true;
            _timerPanel.gameObject.SetActive(true);
        }

        private void TurnOffTimer() {
            _isTimerActive = false;
            _timerPanel.gameObject.SetActive(false);
        }

        private void HideContinueButton() {
            _continueButton.gameObject.SetActive(false);
        }

        private void ExitDialogue() {
            _mainStoryText.text = "";
            HideContent();
            OnEventFinished.Invoke();
        }

    }

}
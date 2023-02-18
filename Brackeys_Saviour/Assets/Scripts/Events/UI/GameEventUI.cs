using System;
using System.Collections.Generic;
using System.Linq;
using Events.GameEvents;
using Ink.Runtime;
using ModestTree;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
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

        [SerializeField]
        private TextMeshProUGUI _mainStoryText;

        [SerializeField]
        private TextMeshProUGUI _headerText;

        [Header("Timer")]
        [SerializeField]
        private Image _timerImage;

        [SerializeField]
        private float _timeToDecide = 25f;

        [SerializeField]
        private GameObject _timerPanel;


        public Action OnEventFinished = delegate { };

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

        public void UpdateUiForEvent(BaseGameEvent baseGameEvent) {
            CleanUpOldEvent();
            baseGameEvent.GetStory();
            StartStory();
        }

        private void CleanUpOldEvent() {
            throw new NotImplementedException();
        }

        private void StartStory() {
            throw new NotImplementedException();
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
        }

        private void ContinueStory() {
            _currentTimer = _timeToDecide;

            if (_story.canContinue) {
                _mainStoryText.text = _story.Continue();
                _currentChoices = _story.currentChoices;
                ProceedChoices();
            } else {
                ExitDialogue();
            }
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
                    // var tagsForContentAtPath = _story.TagsForContentAtPath(_currentChoices[i].pathStringOnChoice);
                    // Debug.Log("There is a choice tag: " + tagsForContentAtPath.Count + " with pathStringOnChoice");
                    //
                    // if (tagsForContentAtPath.Count > 0) {
                    //     Debug.Log("TAG: " + tagsForContentAtPath[0]);
                    // }
                    //
                    // var tagsForContentAtPath1 = _story.TagsForContentAtPath(_currentChoices[i].targetPath.componentsString);
                    // Debug.Log("There is a choice tag: " + tagsForContentAtPath1.Count + " with componentsString");
                    //
                    // if (tagsForContentAtPath1.Count > 0) {
                    //     Debug.Log("TAG: " + tagsForContentAtPath1[0]);
                    // }
                    //
                    // var tagsForContentAtPath2 = _story.TagsForContentAtPath(_currentChoices[i].sourcePath);
                    // Debug.Log("There is a choice tag: " + tagsForContentAtPath2.Count + " with sourcePath");
                    //
                    // if (tagsForContentAtPath2.Count > 0) {
                    //     Debug.Log("TAG: " + tagsForContentAtPath2[0]);
                    // }

                    // _story.currentTags


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
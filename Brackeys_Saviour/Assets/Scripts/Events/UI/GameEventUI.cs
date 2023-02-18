using System;
using System.Collections.Generic;
using System.Linq;
using Events.GameEvents;
using Ink.Runtime;
using ModestTree;
using TMPro;
using UI;
using UnityEngine;

namespace Events.UI {

    public class GameEventUI : ContentUI {

        private Story _story;

        private List<Choice> _currentChoices;

        [SerializeField]
        private ContinueButton _continueButton;

        [SerializeField]
        private List<ChoiceButton> _choiceButtons;

        [SerializeField]
        private TextMeshProUGUI _mainStoryText;

        [SerializeField]
        private TextMeshProUGUI _headerText;

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

        public void TryFirstStory(TextAsset storyJson) {
            ShowContent();
            _story = new Story(storyJson.text);
            ContinueStory();
        }

        private void ContinueStory() {
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
        }

        private void HideContinueButton() {
            _continueButton.gameObject.SetActive(false);
        }

        private void ExitDialogue() {
            _mainStoryText.text = "";
            HideContent();
        }

    }

}
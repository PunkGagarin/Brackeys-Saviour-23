using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace UI.BreatheGame {

    public class MiniGameUI : ContentUI {

        private bool _isPlaying;

        private BreathGameAreaUI _breathGameAreaUI;

        private Slider _slider;
        
        [SerializeField]
        private SliderArrow _sliderArrow;

        [SerializeField]
        private float _sliderSpeed = 3f;

        [SerializeField]
        private Button _startGameButton;

        [SerializeField]
        private Button _pickButton;
        
        public Action<bool> OnGameFinish = delegate {  };
        
        public Action OnHit = delegate {  };
        public Action OnMiss = delegate {  };

        protected override void Awake() {
            base.Awake();
            _breathGameAreaUI = GetComponentInChildren<BreathGameAreaUI>(true);
            _slider = GetComponentInChildren<Slider>(true);

            Assert.IsNotNull(_breathGameAreaUI);
            Assert.IsNotNull(_slider);

            _startGameButton.onClick.AddListener(StartGame);
            _pickButton.onClick.AddListener(PickBlock);
        }
        
        
        private void OnDestroy() {
            _startGameButton.onClick.RemoveAllListeners();
            _pickButton.onClick.RemoveAllListeners();
        }

        private void Spawn() {
            _breathGameAreaUI.SpawnBlocks(3);
        }

        private void Clear() {
            _breathGameAreaUI.CleanBlocks();
        }

        private void StartGame() {
            _isPlaying = true;

            _slider.value = 0;
            
            _startGameButton.gameObject.SetActive(false);
            _pickButton.gameObject.SetActive(true);
            
            StartCoroutine(MoveSlider());
        }

        private void PickBlock() {
            if (_sliderArrow.EntersBlockPosition) {
                _sliderArrow.BreatheGameBlock.gameObject.SetActive(false);
                _sliderArrow.BreatheGameBlock = null;
                OnHit?.Invoke();
                return;
            }
            
            OnMiss?.Invoke();
        }

        private IEnumerator MoveSlider() {
            Clear();
            Spawn();
            var tmpVal = _sliderSpeed;


            while (_isPlaying && _slider.value < .99f && tmpVal > 0) {
                _slider.value = Mathf.Lerp(0, 1, 1 - (tmpVal / _sliderSpeed));
                tmpVal -= Time.deltaTime;
                yield return null;
            }
            Debug.Log("End of first slide");
            StartCoroutine(InvertMoveSlider());
        }

        private IEnumerator InvertMoveSlider() {
            Clear();
            Spawn();
            var tmpVal = _sliderSpeed;


            while (_isPlaying && _slider.value >= 0 && tmpVal > 0) {
                _slider.value = Mathf.Lerp(1, 0, 1 - (tmpVal / _sliderSpeed));
                tmpVal -= Time.deltaTime;
                yield return null;
            }
            Debug.Log("End of Second slide");
            StartCoroutine(MoveSlider());
        }

        public override void ShowContent() {
            base.ShowContent();
            _pickButton.gameObject.SetActive(false);
            _startGameButton.gameObject.SetActive(true);
        }

        public override void HideContent() {
            _pickButton.gameObject.SetActive(false);
            _startGameButton.gameObject.SetActive(true);
            base.HideContent();
        }

        public void LoseMiniGame() {
            OnGameFinish.Invoke(false);
            Debug.Log("we lost mini game!");
        }
        
        public void WinMiniGame() {
            OnGameFinish.Invoke(true);
            Debug.Log("we have won!");
        }


    }

}
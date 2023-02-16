using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace UI.BreatheGame {

    public class MiniGameUI : MonoBehaviour {

        private bool _isPlaying;

        private BreathGameAreaUI _breathGameAreaUI;

        private Slider _slider;

        [SerializeField]
        private float _sliderSpeed = 3f;

        [SerializeField]
        private Button _spawnButton;

        [SerializeField]
        private Button _clearButton;

        [SerializeField]
        private Button _startGameButton;

        [SerializeField]
        private Button _pickButton;

        private void Awake() {
            _breathGameAreaUI = GetComponentInChildren<BreathGameAreaUI>();
            _slider = GetComponentInChildren<Slider>();

            Assert.IsNotNull(_breathGameAreaUI);
            Assert.IsNotNull(_slider);

            _spawnButton.onClick.AddListener(Spawn);
            _clearButton.onClick.AddListener(Clear);
            _startGameButton.onClick.AddListener(StartGame);
            _pickButton.onClick.AddListener(PickBlock);
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
            StartCoroutine(MoveSlider());
        }

        private void PickBlock() {
            var breatheGameBlock = _breathGameAreaUI.PickBlock(_slider.value, _slider.handleRect.sizeDelta.x/2);
            if (breatheGameBlock != null) {
                breatheGameBlock.gameObject.SetActive(false);
            } else {
                Debug.Log("there is no block!");
            }
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


        private void OnDestroy() {
            _spawnButton.onClick.RemoveAllListeners();
            _clearButton.onClick.RemoveAllListeners();
        }
    }

}
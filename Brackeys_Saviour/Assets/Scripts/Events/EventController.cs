using System;
using Audio;
using Events.Pools;
using Events.UI;
using SpiritResources;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Events {

    public class EventController : MonoBehaviour {

        private bool _isTimerGoing;

        private Camera _mainCam;

        private int _currentEventCount;

        [Inject]
        private BasePoolImpl _gameEventPool;

        [Inject]
        private AudioManager _audioManager;

        [Inject]
        private GameEventUI _eventView;

        [SerializeField]
        private EventPopupUI _eventPopup;

        [SerializeField]
        private float _currentEventTimer = 2f;

        [SerializeField]
        private float _eventTimeMin = 15f;

        [SerializeField]
        private float _eventTimeMax = 25f;

        [SerializeField]
        private float _spawnPopupBorderSize = 100f;

        [SerializeField]
        private int _maxEventCount;


        public Action OnMaxValueReach = delegate { };

        private void Awake() {
            _mainCam = Camera.main;
            _gameEventPool.InitPool();
            _isTimerGoing = true;
        }

        private void Start() {
            _eventPopup.button.onClick.AddListener(RegisterEvent);
            _eventView.OnEventFinished += Resume;
        }

        private void Update() {
            if (!_isTimerGoing) return;

            if (_currentEventTimer <= 0) {
                ShowRandomPopup();
                _currentEventTimer = GetNextEventTimer();
            } else {
                _currentEventTimer -= Time.deltaTime;
            }
        }

        private void Resume() {
            _currentEventCount++;
            if (_currentEventCount >= _maxEventCount) {
                OnMaxValueReach.Invoke();
            } else {
                _isTimerGoing = true;
            }
        }

        private void ShowRandomPopup() {
            
            _audioManager.PlayEffectSound("snd_ui_quest_notification");
            StopTimer();
            //MovePopupToRandom
            _eventPopup.gameObject.SetActive(true);
            MovePopup();
        }

        private void MovePopup() {
            var v3Rnd = new Vector3(Random.Range(0 + _spawnPopupBorderSize, Screen.width - _spawnPopupBorderSize),
                Random.Range(0 + _spawnPopupBorderSize, Screen.height - _spawnPopupBorderSize * 1.5f), 14);

            var newPos = _mainCam.ScreenToWorldPoint(v3Rnd);
            newPos.z = 14;

            _eventPopup.transform.position = newPos;
        }

        private float GetNextEventTimer() {
            return Random.Range(_eventTimeMin, _eventTimeMax + 1f);
        }

        private void RegisterEvent() {
            _eventPopup.gameObject.SetActive(false);

            //todo: change to get from event
            var textStory = GetRandomEventText();

            _eventView.HandleStory(textStory);
        }

        public void StopTimer() {
            _isTimerGoing = false;
        }

        private TextAsset GetRandomEventText() {
            var stories = UnityEngine.Resources.LoadAll<TextAsset>("Stories");
            return stories[Random.Range(0, stories.Length)];
        }

    }

}